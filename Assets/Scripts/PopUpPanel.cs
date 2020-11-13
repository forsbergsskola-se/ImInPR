using System;
using UnityEngine;
using UnityEngine.UI;

public class PopUpPanel : MonoBehaviour
{
    public Text confirmText;
    public event Action OnAccept;
    public event Action OnDecline;
    
    public void SetUp(Transform transform, OfficeInteractable officeObject, PopUpManager popUpManager)
    {
        //TODO Make UI Match The OfficeObjects Information
        //this.transform.position = transform.position;
        confirmText.text = ToString(officeObject.name);
        OnAccept += officeObject.IncreaseLevel;
        OnAccept += popUpManager.DealtWithPopUp;
        OnDecline += popUpManager.DealtWithPopUp;
    }

    public void Accept()
    {
        OnAccept?.Invoke();
    }

    public void Decline()
    {
        OnDecline?.Invoke();
    }

    public string ToString(string objectName)
    {
        return $"You are about to upgrade {objectName} \n" +
               "Are you sure you would like to upgrade this?";
    }
}
