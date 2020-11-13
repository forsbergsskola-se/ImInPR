using System;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationPanel : MonoBehaviour
{
    public Text confirmText;
    public event Action OnAccept;
    public event Action OnDecline;
    
    public void SetUpOfficeUpgradeable(Transform parent, OfficeInteractable officeObject, ConfirmationHandler confirmationHandler)
    {
        //TODO Make UI Match The OfficeObjects Information
        //this.parent.position = parent.position;
        confirmText.text = UpgradeString(officeObject.name);
        OnAccept += officeObject.IncreaseLevel;
        OnAccept += confirmationHandler.DealtWithPopUp;
        OnDecline += confirmationHandler.DealtWithPopUp;
    }

    public void SetUp(Transform parent, BandTask task, ConfirmationHandler confirmationHandler)
    {
        confirmText.text = task.task.description;
        OnAccept += confirmationHandler.DealtWithPopUp;
        OnDecline += confirmationHandler.DealtWithPopUp;
    }

    public void Accept()
    {
        OnAccept?.Invoke();
    }

    public void Decline()
    {
        OnDecline?.Invoke();
    }

    public string UpgradeString(string objectName)
    {
        return $"You are about to upgrade {objectName} \n" +
               "Are you sure you would like to upgrade this?";
    }
}
