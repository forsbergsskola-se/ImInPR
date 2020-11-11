using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash 
{
    public int Amount
    {
        get => PlayerPrefs.GetInt("Cash", 1000);
        private set => PlayerPrefs.SetInt("Cash", value);
    }

    public void Add(int value)
    {
        this.Amount += value;
    }

    public bool Spend(int value)
    {
        if (value > this.Amount) return false;

        this.Amount -= value;
        return true;

    }
    
}
