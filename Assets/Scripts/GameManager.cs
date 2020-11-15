using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Cash cash;
    public static List<OfficeInteractable> officeEquipment;
    public TaskGenerator taskGenerator;
    public GameObject ConfirmationPrefab;
    public GameObject BandSelector;
    public GameObject PhoneEventPrefab;
    private void Awake()
    {
        cash = new Cash();
    }

    private void Start()
    {
        officeEquipment = GetComponentsInChildren<OfficeInteractable>().ToList();
        
    }

    private void Update()
    {
        
        #region Testing
        if (Input.GetKeyDown(KeyCode.F1)) //Shows name, level and cost of upgrade of all OfficeInteractables
        {
            foreach (var value in officeEquipment)
            {
                Debug.Log(value);
            }
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            var instance = Instantiate(BandSelector, transform);
            
        }
       #endregion
    }
}
