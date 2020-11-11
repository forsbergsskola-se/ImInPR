using UnityEngine.EventSystems;

public class BoomBox : OfficeInteractable
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        FindObjectOfType<SoundManager>().PlaySound("ThePureHate-GrindCore");
    }
}
