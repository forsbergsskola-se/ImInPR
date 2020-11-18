using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Experience playerXP;
    [SerializeField] private int xpReqToLevel = 100;
    [SerializeField] private Image playerModel;
    [SerializeField] private Sprite[] models;
    
    
    public event Action OnLevelUp;
    public event Action<int, int> OnXPChanged;
    public int Level
    {
        get => PlayerPrefs.GetInt($"{this.name}_Level");
        private set
        {
            PlayerPrefs.SetInt($"{this.name}_Level", value);
        }
    }

    private void Update()
    {
        switch (Level)
        {
            case 1: 
                break;
            case 2: 
                break;
            case 3: 
                break;
            case 4: 
                break;
            case 5: 
                break;
        }

    }

    public void LevelUp()
    {
        playerModel.sprite = models[++Level];
        playerXP.ExperienceAmount -= xpReqToLevel;
        OnLevelUp?.Invoke();
    }

    public void AddXp(int value)
    {
        if (value <= 0) return;
        
        OnXPChanged?.Invoke(playerXP.ExperienceAmount, value);
        
        playerXP.ExperienceAmount += value;
        
        if (playerXP.ExperienceAmount >= xpReqToLevel)
        {
            //todo Notification that LevelUp is ready.
            
            LevelUp();
        }
    }

    public void LoseXp(int value)
    {
        //updateXpBar(playerXP.ExperienceAmount, playerXP.ExperienceAmount - value);
        playerXP.ExperienceAmount -= value;
    }

    public float xpPercentage(int xp) => xp / xpReqToLevel;
}
