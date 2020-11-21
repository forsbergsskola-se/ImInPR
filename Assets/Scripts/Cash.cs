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
    
    public void TryAdd(int value)
    {
        if (value > 0)
        {
            Add(value);
        }
    }

    public void Add(int value)
    {
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
