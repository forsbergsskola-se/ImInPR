using System;
using UnityEngine;
using UnityEngine.UI;

public class ComputerUpgrade : MonoBehaviour
{
    public Text confirmText;
    public event Action OnConfirm;

    private void Start()
    {
        var computer = FindObjectOfType<Computer>();
        OnConfirm += computer.IncreaseLevel;
    }

    private void Update()
    {
        if (FindObjectOfType<Computer>().Level >= 5)
        {
            UpdateUI("Computer Has Reached Max Level");
            return;
        }
        UpdateUI(FindObjectOfType<Computer>().ToString());
    }

    private void UpdateUI(string text)
    {
        confirmText.text = text;
    }

    public void Confirm()
    {
        if (FindObjectOfType<Computer>().Level >= 5) return;
        OnConfirm?.Invoke();
    }
}
