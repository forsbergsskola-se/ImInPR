using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class BandBehaviour : MonoBehaviour, IPointerClickHandler
{
    public SetString onLevelUp, onGenreSetUp, onBandNameSetUp;
    public SetFloat onAwarenessChange, onPopularityChange;
    public SetSprite onLogoSetUp;
    public Band bandConfig;
    public int baseCashGenerated;
    public float generateInterval = 12f;
    [Range(0f, 1f)] public float likelyHoodToGenerateTask;
    private BandExperience awareness;
    private BandExperience popularity;
    private float _elapsedTime;

    [Header("Click Attributes")] [SerializeField] [Range(0f, 1f)]
    private float chanceForMoney;
    [SerializeField] [Range(0f, 1f)]
    private float chanceForPlayerExp;
    [SerializeField] [Range(0f, 1f)]
    private float chanceForBandAwareness;
    [SerializeField] [Range(0f, 1f)]
    private float chanceForBandPopularity;

    public int MoneyPerMinute => baseCashGenerated * CurrentLevel * Mathf.RoundToInt(60 / generateInterval);

    public int CurrentLevel
    {
        get => PlayerPrefs.GetInt($"{bandConfig.name}_Level", (int)bandConfig.Tier);
        private set => PlayerPrefs.SetInt($"{bandConfig.name}_Level", value);
    }

    public int RequiredExp => 100 + (5 * (CurrentLevel - 1));

    public void SetUp(Band band)
    {
        bandConfig = band;
        awareness = new BandExperience(this, "Awareness", bandConfig.name);
        popularity = new BandExperience(this, "Popularity", bandConfig.name);
        onGenreSetUp.Invoke(band.genre);
        onBandNameSetUp.Invoke(band.name);
        onLogoSetUp.Invoke(band.thumbnail);
        onAwarenessChange.Invoke(CalculateDistanceToNextLevel(awareness));
        onPopularityChange.Invoke(CalculateDistanceToNextLevel(popularity));
        onLevelUp.Invoke(CurrentLevel.ToString());
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime < generateInterval) return;
        FindObjectOfType<GameManager>().cash.Add(baseCashGenerated * CurrentLevel);
        _elapsedTime -= generateInterval;
        if (Random.Range(0f, 1f) < likelyHoodToGenerateTask)
        {
            GenerateTask();
        }
    }

    void GenerateTask()
    {
        var newTask = FindObjectOfType<GameManager>().taskGenerator.SpawnTask(this);
        if (newTask == null) return;
        newTask.OnRewardCollected += OnReward;
        newTask.OnDestroyed += UnsubscribeFromTask;
    }

    public void CheckIfLeveledUp()
    {
        if (awareness.Amount == RequiredExp && popularity.Amount == RequiredExp)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        FindObjectOfType<SoundManager>().levelUpSounds.PlayRandomSound();
        CurrentLevel++;
        awareness.Amount = 0;
        popularity.Amount = 0;
        onLevelUp.Invoke(CurrentLevel.ToString());
    }


    public void OnReward(RewardAmount[] rewardAmounts)
    {
        foreach (var rewardAmount in rewardAmounts)
        {
            switch (rewardAmount.type.name)
            {
                case "Awareness":
                    awareness.Amount += rewardAmount.amount;
                    onAwarenessChange.Invoke(CalculateDistanceToNextLevel(awareness));
                    break;
                case "Popularity":
                    popularity.Amount += rewardAmount.amount;
                    onPopularityChange.Invoke(CalculateDistanceToNextLevel(popularity));
                    break;
            }
        }
    }

    float CalculateDistanceToNextLevel(BandExperience experience)
    {
        return (float)experience.Amount / RequiredExp;
    }

    void UnsubscribeFromTask(BandTask task)
    {
        task.OnDestroyed -= UnsubscribeFromTask;
        task.OnRewardCollected -= OnReward;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var randomNum = Random.Range(0.0f, 1.0f);
        var gm = FindObjectOfType<GameManager>();
        if (randomNum < chanceForMoney)
        {
            gm.cash.Add(1);
        }
        if (randomNum > Mathf.Lerp(1, 0, chanceForPlayerExp))
        {
            FindObjectOfType<Player>().AddXp(1);
            FindObjectOfType<SoundManager>().PlayGameSound("upgrade");
        }
        if (randomNum < chanceForBandAwareness)
        {
            if (awareness.Amount != RequiredExp)
            {
                awareness.Amount++;
                onAwarenessChange.Invoke(CalculateDistanceToNextLevel(awareness));
                var popUp = Instantiate(gm.ImagePopUp, this.transform);
                popUp.GetComponent<ImagePopUp>().SetUp(0);
            }
        }

        if (randomNum > Mathf.Lerp(1, 0, chanceForBandPopularity))
        {
            if (popularity.Amount != RequiredExp)
            {
                popularity.Amount++; 
                onPopularityChange.Invoke(CalculateDistanceToNextLevel(popularity));
                var popUp = Instantiate(gm.ImagePopUp, this.transform); 
                popUp.GetComponent<ImagePopUp>().SetUp(1);   
            }
        }
    }
}
