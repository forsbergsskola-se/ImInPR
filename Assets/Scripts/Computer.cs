using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class Computer : OfficeInteractable
{
   protected override void Start()
   {
      base.Start();
      OnLevelUp += gm.taskGenerator.UpdateProgressCircles;
      gm.taskGenerator.UpdateProgressCircles();
   }

   public override void OnPointerClick(PointerEventData eventData)
   {
      gm.taskGenerator.ToggleGraphics();
   }

   public override string ToString() => $"Upgrade Computer To Level {Level + 1}                                         {ActualCost()}$";
}
