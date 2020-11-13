using UnityEngine.EventSystems;

public class Computer : OfficeInteractable
{
   public override void OnPointerClick(PointerEventData eventData)
   {
      Instantiate(gm.BandSelector, gm.transform);
   }
}
