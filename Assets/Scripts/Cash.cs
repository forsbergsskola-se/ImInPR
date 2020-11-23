using System;
using UnityEngine;

public class Cash
{
    public event Action OnCashChanged;

    public int Amount
    {
        get => PlayerPrefs.GetInt("Cash", 0);
        private set => PlayerPrefs.SetInt("Cash", Mathf.Clamp(value, 0, int.MaxValue));
    }
    
    public void Add(int value)
    {
        if (value == 0) return;
        this.Amount += value;
        OnCashChanged?.Invoke();
    }

    public bool Spend(int value)
    {
        if (value > this.Amount) return false;

        this.Amount -= value;
        OnCashChanged?.Invoke();
        return true;
    }

    public bool CanAfford(int value)
    {
        return value <= this.Amount;
    }
    
    
}
