using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BandSelectorController : MonoBehaviour
{
    [SerializeField] private Band[] bands;
    [SerializeField] private GameObject bandSelectorItem;
    [SerializeField] private int amountBandsToDisplay = 3;
    
    private List<Band> _eligibleBands;
    
    private void PopulateList(BandTier tier)
    {
        _eligibleBands.Clear();
        
        foreach (var band in bands)
        {
            if (band.Tier <= tier && !band.isOwned)
            {
                _eligibleBands.Add(band);
            }
        }
        
        AddToBandSelector(SelectRandomBands(amountBandsToDisplay));
        
    }

    private void AddToBandSelector(List<Band> itemsToDisplay)
    {
        foreach (var band in itemsToDisplay)
        {
            var instance = Instantiate(bandSelectorItem, transform);
        }
    }
    
    private List<Band> SelectRandomBands(int amount)
    {
        if (_eligibleBands.Count == 0) return default;
        
        if (amount > _eligibleBands.Count) 
            amount = _eligibleBands.Count;
        
        List<Band> randomBands = new List<Band>();
        
        for (int i = 0; i < amount; i++)
        {
            randomBands.Add(_eligibleBands[Random.Range(0, _eligibleBands.Count)]);
        }

        return randomBands;
    }

    public void PrintList()
    {
        foreach (var VARIABLE in bands)
        {
            Debug.Log(VARIABLE);
        }
    }
}
