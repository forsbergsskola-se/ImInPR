using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Experience playerXP;
    [SerializeField] private int xpReqToLevel = 100;
    [SerializeField] private Image playerModel;
    [SerializeField] private Sprite[] models;
    [SerializeField] private Image xpBar;
    
    public event Action OnLevelUp;
    //public event Action OnXPChanged;
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
        playerModel.sprite = models[++Level];
        playerXP.ExperienceAmount -= xpReqToLevel;
        OnLevelUp?.Invoke();
    }

    public void AddXP(int value)
    {
        if (value <= 0) return;
        
        updateXpBar(playerXP.ExperienceAmount, playerXP.ExperienceAmount + value);
        playerXP.ExperienceAmount += value;
        
        if (playerXP.ExperienceAmount >= xpReqToLevel)
        {
            //todo Notification that LevelUp is ready.
            
            LevelUp();
        }
    }

    public void LoseXP(int value)
    {
        updateXpBar(playerXP.ExperienceAmount, playerXP.ExperienceAmount - value);
        playerXP.ExperienceAmount -= value;
        
    }

    public float xpPercentage() => playerXP.ExperienceAmount / xpReqToLevel;

    private void updateXpBar(float start, float end)
    {
        float elapsedTime = 0;
        float timeToComplete = 1f;
        
        while (elapsedTime < timeToComplete)
        {
            elapsedTime += Time.deltaTime;
            xpBar.fillAmount = Mathf.Lerp(start, end, elapsedTime);
        }
    }
}
