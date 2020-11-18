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
        get => PlayerPrefs.GetInt($"{this.name}_Level", 1);
        private set => PlayerPrefs.SetInt($"{this.name}_Level", value);
    }

    public void Start()
    {
        Debug.Log(playerXP.ExperienceAmount);
    }

    public void LevelUp()
    {
        playerModel.sprite = models[Mathf.Clamp(++Level, 0, models.Length - 1)];
        playerXP.ExperienceAmount -= xpReqToLevel;
        OnXPChanged?.Invoke(XpPercentage());
        OnLevelUp?.Invoke();
    }

    public void AddXp(int value)
    {
        if (value <= 0) return;
        
        playerXP.ExperienceAmount += value;
        OnXPChanged?.Invoke(XpPercentage());
        
        if (playerXP.ExperienceAmount >= xpReqToLevel)
        {
            LevelUp();
        }
    }

    public void LoseXp(int value)
    {
        playerXP.ExperienceAmount = Mathf.Clamp(playerXP.ExperienceAmount - value, 0, xpReqToLevel);
        OnXPChanged?.Invoke(XpPercentage());
    }

    public float XpPercentage() => (playerXP.ExperienceAmount / xpReqToLevel) * 100;
}
