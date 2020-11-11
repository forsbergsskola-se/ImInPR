using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CashUI : MonoBehaviour
{
    private GameManager gm;
    [SerializeField] private TextMeshProUGUI cashText;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.cash.OnCashChanged += UpdateCashUILabel;
        UpdateCashUILabel();
    }

    void UpdateCashUILabel()
    {
        cashText.SetText($"{gm.cash.Amount} Cash");
    }

    private void OnDestroy()
    {
        gm.cash.OnCashChanged -= UpdateCashUILabel;
    }
}
