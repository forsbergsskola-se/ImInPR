using UnityEngine;
using UnityEngine.EventSystems;

public class Plant : OfficeInteractable, IPointerClickHandler
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        this.IncreaseLevel();
    }
    
}

