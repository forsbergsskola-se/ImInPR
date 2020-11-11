using UnityEngine.EventSystems;

public class BoomBox : OfficeInteractable, IPointerClickHandler
{
    
    public void OnPointerClick(PointerEventData eventData)
    {
        FindObjectOfType<SoundManager>().PlaySound("ThePureHate-GrindCore");
    }
}
