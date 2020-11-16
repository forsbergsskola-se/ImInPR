using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BandSelectorItem : MonoBehaviour, IPointerClickHandler
{
    private Band band;
    private GameManager _gm;

    [SerializeField] private TextMeshProUGUI bandName;
    [SerializeField] private TextMeshProUGUI genre;
    [SerializeField] private TextMeshProUGUI bioText;
    [SerializeField] private Image thumbnail;

    private void Start()
    {
        _gm = FindObjectOfType<GameManager>();
    }

    public void Setup(Band value)
    {
        band = value;

        bandName.SetText(band.name);
        genre.SetText(band.genre);
        bioText.SetText(band.bioText);
        //if(thumbnail.sprite != null)
            thumbnail.sprite = band.thumbnail;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        var instance = Instantiate(_gm.BandUIElement, _gm.BandUIContainer);
        instance.GetComponent<BandBehaviour>().SetUp(band);
    }
}
