using UnityEngine.UI;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BandBehaviour))]
public class BandUI : MonoBehaviour
{
    public Text lvl, genre, bandName;
    public Image popularity, awareness, logo;

    public void SetUp(Band band)
    {
        genre.text = band.genre;
        bandName.text = band.name;
        logo.sprite = band.thumbnail;
    }
    
    public void UpdateUI(int currentLvl, float popularity, float awareness)
    {
        this.awareness.fillAmount = awareness;
        this.popularity.fillAmount = popularity;
        this.lvl.text = currentLvl.ToString();
    }
}
