using UnityEngine.EventSystems;

public class Computer : OfficeInteractable
{
   public override void OnPointerClick(PointerEventData eventData)
   {
      base.OnPointerClick(eventData);
      //Instantiate(gm.BandSelector, gm.transform);
   }
}
