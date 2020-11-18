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
    public event Action<float> OnXPChanged;
    public int Level
    {
        get => PlayerPrefs.GetInt($"{this.name}_Level");
        private set
        {
            PlayerPrefs.SetInt($"{this.name}_Level", value);
        }
    }

    public void LevelUp()
    {
        playerModel.sprite = models[Mathf.Clamp(++Level, 0, models.Length - 1)];
        playerXP.ExperienceAmount -= xpReqToLevel;
        OnLevelUp?.Invoke();
    }

    public void AddXp(int value)
    {
        if (value <= 0) return;
        
        OnXPChanged?.Invoke(XpPercentage());
        
        playerXP.ExperienceAmount += value;
        
        if (playerXP.ExperienceAmount >= xpReqToLevel)
        {
            //todo Notification that LevelUp is ready.
            //Exclamation Mark?
            //Tell Business Card
        }
    }

    public void LoseXp(int value)
    {
        //updateXpBar(playerXP.ExperienceAmount, playerXP.ExperienceAmount - value);
        playerXP.ExperienceAmount = Mathf.Clamp(playerXP.ExperienceAmount - value, 0, xpReqToLevel);
    }

    public float XpPercentage() => playerXP.ExperienceAmount / xpReqToLevel;
}
