﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Experience playerXP;
    [SerializeField] private int xpReqToLevel = 100;
    [SerializeField] private Image playerModel;
    [SerializeField] private Sprite[] models;
    public int Level
    {
        get => PlayerPrefs.GetInt($"{this.name}_Level");
        private set
        {
            PlayerPrefs.SetInt($"{this.name}_Level", value);
            //playerLvlText.text = Level.ToString();
        }
    } 

    public void LevelUp()
    {
        playerModel.sprite = models[++Level];
        playerXP.ExperienceAmount -= xpReqToLevel;
    }

    public void AddXP(int value)
    {
        if (value <= 0) return;
        
        playerXP.ExperienceAmount += value;
        if (playerXP.ExperienceAmount >= xpReqToLevel)
        {
            //todo Notification that LevelUp is ready.
            //perhaps Add levelUp to an onAcceptClicked Event on Notification?
            
            
            LevelUp();
        }
    }
}
