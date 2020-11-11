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
        //todo
        throw new System.NotImplementedException();
    }
}
