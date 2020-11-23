using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOwnedBands : MonoBehaviour
{
    [SerializeField] private BandList bandList;
    [SerializeField] private GameManager _gm;

    private void Start()
    {
        foreach (var band in bandList.bands)
        {
            if (!band.GetOwned()) continue;
            var instance = Instantiate(_gm.BandUIElement, _gm.BandUIContainer);
            instance.GetComponent<BandUI>().SetUp(band);
            instance.GetComponent<BandBehaviour>().SetUp(band);
        }
    }
}
