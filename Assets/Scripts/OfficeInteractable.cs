using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class OfficeInteractable : MonoBehaviour, IPointerClickHandler
{
    protected GameManager gm;
    public Sprite[] models;

    public int Level
    {
        get => PlayerPrefs.GetInt($"{name}_Level", 1);
        private set => PlayerPrefs.SetInt($"{name}_Level", value);
    }
    public int levelUpCost;

    public event Action OnLevelUp;
    protected virtual void Start()
    {
        gm = FindObjectOfType<GameManager>();
        GetComponent<Image>().sprite = models[Mathf.Clamp(Level - 1, 0, models.Length - 1)];
    }

    public virtual void IncreaseLevel()
    {
        if (gm.cash.Spend(ActualCost()))
        {
            Debug.Log($"Upgraded {name}");
            Level++;
            OnLevelUp?.Invoke();
            FindObjectOfType<BG>().LevelUp();
        }

        GetComponent<Image>().sprite = models[Mathf.Clamp(Level - 1, 0, models.Length - 1)];
    }

    public int ActualCost()
    {
        return levelUpCost * Level * 3;
    }

    public override string ToString() => $"{this.name} : Level {Level}, costs {ActualCost()} to upgrade.";

    public virtual void OnPointerClick(PointerEventData eventData)
    {
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
        }
    }
    
    private string UpgradeText() => $"Upgrade {this.name} To \n" +
                                    $"Level {Level + 1} : Costs {ActualCost()}";

    void UnsubscribeFromConfirm(ConfirmationPanel confirmationPanel)
    {
        confirmationPanel.OnConfirm -= IncreaseLevel;
        confirmationPanel.OnDestroyed -= UnsubscribeFromConfirm;
        Debug.Log($"{this.name} unsubscribed from {confirmationPanel.GetHashCode()}");
    }
}
