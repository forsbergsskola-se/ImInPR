using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Cash cash;
    
    public static List<OfficeInteractable> officeEquipment;
    private void Start()
    {
        officeEquipment = GetComponentsInChildren<OfficeInteractable>().ToList();
        cash = new Cash();
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
        #endregion
    }
}
