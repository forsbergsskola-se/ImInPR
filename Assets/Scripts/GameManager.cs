using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Cash cash;
    
    public static List<OfficeInteractable> officeEquipment;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var value in officeEquipment)
            {
                Debug.Log(cash.Amount);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            FindObjectOfType<SoundManager>().PlaySound("TestSouNd");
        }
        #endregion
    }
}
