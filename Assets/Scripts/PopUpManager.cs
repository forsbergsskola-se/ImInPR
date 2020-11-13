﻿using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public bool isCreated;
    [SerializeField] private GameObject PopUpPrefab;
    private GameObject instance;

    public void PopUpMenu(Transform objectTransform, OfficeInteractable officeObject)
    {
        if (!isCreated) 
        {
            instance = Instantiate(PopUpPrefab, objectTransform);
            isCreated = true;
        }
    }

    public void AcceptPopUp()
    {
        // Give task
        isCreated = false;
    }

    public void DeclinePopUp()
    {
        isCreated = false;
    }

    public void DealtWithPopUp()
    {
        Destroy(instance);
        isCreated = false;
    }
}