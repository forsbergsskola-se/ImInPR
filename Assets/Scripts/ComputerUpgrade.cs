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
        UpdateUI(FindObjectOfType<Computer>().ToString());
    }

    private void UpdateUI(string text)
    {
        confirmText.text = text;
    }

    public void Confirm()
    {
        OnConfirm?.Invoke();
    }
}
