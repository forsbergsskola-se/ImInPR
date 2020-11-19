using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CashUI : MonoBehaviour
{
    private GameManager gm;
    private SoundManager _soundManager; 
    [SerializeField] private TextMeshProUGUI cashText;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        _soundManager = FindObjectOfType<SoundManager>();
        gm.cash.OnCashChanged += UpdateCashUILabel;
        gm.cash.OnCashChanged += ching;
        UpdateCashUILabel();
    }

    void UpdateCashUILabel() 
    {
        cashText.SetText($"{gm.cash.Amount} Cash");
    }

    void ching()
    {
        Debug.Log("Ching");
        _soundManager.PlayGameSound("Cash");
    }

    private void OnDestroy()
    {
        gm.cash.OnCashChanged -= UpdateCashUILabel;
        gm.cash.OnCashChanged -= ching;
    }
}
