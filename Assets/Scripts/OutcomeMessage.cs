using TMPro;
using UnityEngine;

public class OutcomeMessage : MonoBehaviour
{
    public TMP_Text describingText, outcomeText;

    public void SetUp(string describingText, string outcomeText)
    {
        this.describingText.text = describingText;
        this.outcomeText.text = outcomeText;
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
