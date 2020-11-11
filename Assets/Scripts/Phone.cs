using UnityEngine.EventSystems;

public class Phone : OfficeInteractable
{

    public override void OnPointerClick(PointerEventData eventData)
    {
        gm.cash.Add(5);
    }
}
