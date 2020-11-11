using UnityEngine;
using UnityEngine.EventSystems;

public class Plant : OfficeInteractable
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        this.IncreaseLevel();
    }
    
}

