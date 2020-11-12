using UnityEngine.EventSystems;

public class BoomBox : OfficeInteractable
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        FindObjectOfType<SoundManager>().PlaySong("ThePureHate-GrindCore");
    }
}
