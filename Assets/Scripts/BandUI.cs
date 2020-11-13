using UnityEngine.UI;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BandBehaviour))]
public class BandUI : MonoBehaviour
{
    public TMP_Text lvl;
    public Image popularity, awareness;
    public void UpdateUI(int currentLvl, float popularity, float awareness)
    {
        this.awareness.fillAmount = awareness;
    }
}
