using UnityEngine;
using UnityEngine.EventSystems;

public class Plant : OfficeInteractable, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        this.IncreaseLevel();
    }
    
}

