using System;
using UnityEngine;

public abstract class OfficeInteractable : MonoBehaviour
{
    private GameManager gm;
    public Sprite[] models; 
    public int Level { get; private set; }
    public int levelUpCost;

    public event Action OnLevelUp;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        PlayerPrefs.GetInt($"{name}_Level", 0);
    }

    public virtual void IncreaseLevel()
    {
        if (gm.cash.Spend(ActualCost()))
        {
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

    private void OnDestroy() => SaveState();
    void SaveState() => PlayerPrefs.SetInt($"{name}_Level", Level);
}
