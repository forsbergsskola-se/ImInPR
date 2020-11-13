using UnityEngine;
using UnityEngine.EventSystems;

public class Chair : OfficeInteractable
{
    
    public void Interact()
    {
        Debug.Log("Chair clicked via Interface");
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        //todo add chair specific logic?
    }
}
