using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

   private void Start()
   {
       slider = GetComponent<Slider>();
       slider.maxValue = FindObjectOfType<Player>().xpReqToLevel;
       UpdateBar(FindObjectOfType<Player>().ExperienceAmount);
   }

   public void UpdateBar(float value)
    {
        slider.value = value;
    }
}
