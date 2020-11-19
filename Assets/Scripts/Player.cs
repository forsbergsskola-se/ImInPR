using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    [SerializeField] private Image playerModel;
    [SerializeField] private Sprite[] models;
    [SerializeField] private ProgressBar xpBar;
    public event Action OnLevelUp;
    
    public float XpPercentage => Convert.ToSingle(ExperienceAmount / xpReqToLevel);
    [SerializeField] private int xpReqToLevel = 100;
    public int ExperienceAmount
    {
        get => PlayerPrefs.GetInt(this.name, 0);
        set => PlayerPrefs.SetInt(this.name, value); 
    }
    
    public int Level
    {
        get => PlayerPrefs.GetInt($"{this.name}_Level", 1);
        private set
        {
            PlayerPrefs.SetInt($"{this.name}_Level", value);
            OnLevelUp?.Invoke();
        }
    }

    public void AddXp(int value)
    {
        if (value <= 0) return;
        
        ExperienceAmount += value;
        
        if (ExperienceAmount >= xpReqToLevel)
        {
            LevelUp();
        }
        xpBar.UpdateBar(ExperienceAmount);
    }

    public void LoseXp(int value)
    {
        if (value <= 0) return;
        ExperienceAmount = Mathf.Clamp(ExperienceAmount - value, 0, xpReqToLevel);
    }
    
    public void LevelUp()
    {
        Level++;
        if (Level == 5)
        {
            var instance = Instantiate(FindObjectOfType<GameManager>().BandSelector, FindObjectOfType<GameManager>().transform);
            instance.GetComponent<BandSelectorController>().PopulateList(BandTier.Tier2);
        }
        else if (Level == 10)
        {
            var instance = Instantiate(FindObjectOfType<GameManager>().BandSelector, FindObjectOfType<GameManager>().transform);
            instance.GetComponent<BandSelectorController>().PopulateList(BandTier.Tier3);
        }
        else if (Level == 15)
        {
            var instance = Instantiate(FindObjectOfType<GameManager>().BandSelector, FindObjectOfType<GameManager>().transform);
            instance.GetComponent<BandSelectorController>().PopulateList(BandTier.Tier3);
        }
        
        playerModel.sprite = models[Mathf.Clamp(Level / 4, 0, models.Length - 1)];
        ExperienceAmount -= xpReqToLevel;
    }
    
    private void Start() 
    {
        Debug.Log(Level);
        playerModel.sprite = models[Mathf.Clamp(Level / 4, 0, models.Length - 1)];
        xpBar.UpdateBar(ExperienceAmount);
    }
}
