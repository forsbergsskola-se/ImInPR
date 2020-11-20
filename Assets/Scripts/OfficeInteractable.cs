using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class OfficeInteractable : MonoBehaviour, IPointerClickHandler
{
    protected GameManager gm;
    public Sprite[] models;
    public int[] prices;

    public int Level
    {
        get => PlayerPrefs.GetInt($"{name}_Level", 1);
        private set => PlayerPrefs.SetInt($"{name}_Level", value);
    }
    
    public event Action OnLevelUp;
    protected virtual void Start()
    {
        gm = FindObjectOfType<GameManager>();
        var temp = GetComponent<Image>().sprite = models[Mathf.Clamp(Level - 1, 0, models.Length - 1)];
        GetComponent<RectTransform>().sizeDelta = new Vector2(temp.rect.width, temp.rect.height);
    }
    
    public virtual void IncreaseLevel()
    {
        if (gm.cash.Spend(ActualCost()))
        {
            Level++;
            OnLevelUp?.Invoke();
            FindObjectOfType<BG>().LevelUp();
            FindObjectOfType<SoundManager>().PlayGameSound("upgrade1");
        }

        var temp = GetComponent<Image>().sprite = models[Mathf.Clamp(Level - 1, 0, models.Length - 1)];
        GetComponent<RectTransform>().sizeDelta = new Vector2(temp.rect.width, temp.rect.height);
    }

    public int ActualCost() => prices[Level - 1];

    public override string ToString() => $"{this.name} : Level {Level}, costs {ActualCost()} to upgrade.";

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (Level == 5)
        {
            Instantiate(gm.MaxLevelPrefab, gm.transform);
            return;
        }
        if (gm.cash.CanAfford(ActualCost()))
        {
            var confirmInstance= Instantiate(gm.ConfirmationPrefab, gm.transform);
            var confirmationPanel = confirmInstance.GetComponent<ConfirmationPanel>();
            confirmationPanel.SetUp(this.UpgradeText());
            confirmationPanel.OnConfirm += IncreaseLevel;
            confirmationPanel.OnDestroyed += UnsubscribeFromConfirm;
        }
        else
        {
            var cannotAffordInstance = Instantiate(gm.CannotAffordPrefab, gm.transform);
            cannotAffordInstance.GetComponent<ConfirmationPanel>().SetUp($"You can't afford this yet! it costs {ActualCost()}$");
        }
    }

    public void OnClick() => OnPointerClick(default);
    
    private string UpgradeText() => $"Upgrade {this.name} To \n" +
                                    $"Level {Level + 1} : Costs {ActualCost()}";

    void UnsubscribeFromConfirm(ConfirmationPanel confirmationPanel)
    {
        confirmationPanel.OnConfirm -= IncreaseLevel;
        confirmationPanel.OnDestroyed -= UnsubscribeFromConfirm;
    }
}
