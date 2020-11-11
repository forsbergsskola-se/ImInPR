using UnityEngine.EventSystems;

public class Phone : OfficeInteractable, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        gm.cash.Add(5);
    }
}
