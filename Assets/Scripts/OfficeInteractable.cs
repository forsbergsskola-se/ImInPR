using System;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class OfficeInteractable : MonoBehaviour, IPointerClickHandler
{
    protected GameManager gm;
    public Sprite[] models; 
    public int Level { get; private set; }
    public int levelUpCost;
    private ConfirmationPanel _confirmationPanel;

    public event Action OnLevelUp;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        Level = PlayerPrefs.GetInt($"{name}_Level", 0); //todo not sure this is working
    }

    public virtual void IncreaseLevel()
    {
        _confirmationPanel.OnAccept -= IncreaseLevel;
        if (gm.cash.Spend(ActualCost()))
        {
            Debug.Log($"Upgrade {name}");
            //SpawnFloating Text
            Level++;
            OnLevelUp?.Invoke();
            //Increase levelUpCost??
        }
    }

    public int ActualCost()
    {
        //todo implement proper costIncrease per levelUp
        return levelUpCost * Level;
    }

    public override string ToString() => $"{this.name} : Level {Level}, costs {ActualCost()} to upgrade.";

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        //TODO Add Parameters To PopUpMenu
        if (gm.cash.CanAfford(ActualCost()))
        {
            var confirmInstance= Instantiate(gm.ConfirmationPrefab, gm.transform);
            _confirmationPanel = confirmInstance.GetComponent<ConfirmationPanel>();
            _confirmationPanel.SetUpOfficeUpgradeable(this);
            _confirmationPanel.OnAccept += IncreaseLevel;
        }
        Debug.Log($"Clicked on {name}");
    }

    private void OnDestroy() => SaveState();
    
    void SaveState() => PlayerPrefs.SetInt($"{name}_Level", Level);
}
