using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProgressCircle : MonoBehaviour, IPointerClickHandler
{
    public bool isUnlocked;
    public bool isBeingUsed;
    private bool canCollect;
    public Action<ProgressCircle> OnCollect;
    public Image image;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (canCollect)
        {
            canCollect = false;
            OnCollect?.Invoke(this);
            isBeingUsed = false;
            image.fillAmount = 0;
        }
    }

    public void UpdateFill(float amount)
    {
        image.fillAmount = amount;
    }

    public void Done()
    {
        canCollect = true;
    }
}
