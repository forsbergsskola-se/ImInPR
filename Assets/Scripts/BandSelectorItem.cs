using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BandSelectorItem : MonoBehaviour
{
    private Band band;

    [SerializeField] private TextMeshProUGUI bandName;
    [SerializeField] private TextMeshProUGUI genre;
    [SerializeField] private TextMeshProUGUI bioText;
    [SerializeField] private Image thumbnail;
    
    public void Setup(Band value)
    {
        band = value;

        bandName.SetText(band.name);
        genre.SetText(band.genre);
        bioText.SetText(band.bioText);
        thumbnail.sprite = band.thumbnail;

    }
}
