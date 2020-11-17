using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProgressCircle : MonoBehaviour, IPointerClickHandler
{
    public bool isUnlocked;
    public bool isBeingUsed;
    private bool canCollect;
    public Action OnCollect;
    public Image image;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (canCollect)
        {
            canCollect = false;
            OnCollect?.Invoke();
            isBeingUsed = false;
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
