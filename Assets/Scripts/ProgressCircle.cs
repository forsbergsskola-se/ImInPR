using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProgressCircle : MonoBehaviour, IPointerClickHandler
{
    public bool isUnlocked;
    public bool isBeingUsed;
    private bool canCollect;
    public int order;
    public Action<ProgressCircle> OnCollect;
    public Image image;
    public Color[] colors;

    private async void Start()
    {
        await Task.Delay(TimeSpan.FromSeconds(0.1));
        if (isUnlocked)
        {
            image.fillAmount = 0;
        }
    }

    private void Update()
    {
        image.color = colors[Convert.ToInt32(isUnlocked)];
    }

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
