using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BandSelectorController : MonoBehaviour
{
    [SerializeField] private BandList bands;
    [SerializeField] private GameObject bandSelectorItem;
    [SerializeField] private int amountBandsToDisplay = 3;
    
    private List<Band> _eligibleBands;

    private void Start()
    {
        _eligibleBands = new List<Band>();
        //PopulateList(BandTier.Tier1);
    }

    public void PopulateList(BandTier tier)
    {
        _eligibleBands.Clear();
        
        foreach (var band in bands.bands)
        {
            if (band.Tier <= tier && !band.GetOwned())
            {
                _eligibleBands.Add(band);
            }
        }

        var tmp = SelectRandomBands(amountBandsToDisplay);
        AddToBandSelector(tmp);
    }

    private void AddToBandSelector(List<Band> itemsToDisplay)
    {
        if (itemsToDisplay.Count == 0) return;
        foreach (var band in itemsToDisplay)
        {
            var instance = Instantiate(bandSelectorItem, transform);
            instance.GetComponent<BandSelectorItem>().Setup(band, this);
            instance.GetComponent<BandSelectorItem>().OnItemSelected += killmepls;
        }
    }
    
    private List<Band> SelectRandomBands(int amount)
    {
        if (_eligibleBands.Count == 0) return default;
        
        if (amount > _eligibleBands.Count) 
            amount = _eligibleBands.Count;
        
        List<Band> randomBands = new List<Band>();
        
        while(randomBands.Count < amount)
        {
            var temp = _eligibleBands[Random.Range(0, _eligibleBands.Count)];
            if(!randomBands.Contains(temp))
                randomBands.Add(temp);
        }

        return randomBands;
    }

    public void killmepls(BandSelectorItem bsi)
    {
        bsi.GetComponent<BandSelectorItem>().OnItemSelected -= killmepls;
        Destroy(gameObject);
    }
}
