using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OfficeInteractable : MonoBehaviour
{
    private GameManager gm;
    public Sprite[] models; 
    public int Level { get; private set; }
    public int levelUpCost;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public virtual void IncreaseLevel()
    {
        if (gm.cash.Spend(ActualCost()))
        {
            //SpawnFloating Text
            Level++;
            //Increase levelUpCost??
        }
    }

    public int ActualCost()
    {
        return levelUpCost * Level;
    }
    
    
}
