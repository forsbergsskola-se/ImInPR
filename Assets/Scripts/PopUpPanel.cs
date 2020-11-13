using System;
using UnityEngine;

public class PopUpPanel : MonoBehaviour
{
    public event Action OnAccept;
    public event Action OnDecline;
    
    void SetUp(OfficeInteractable officeObject, PopUpManager popUpManager)
    {
        //TODO Make UI Match The OfficeObjects Information
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
}
