using System;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationPanel : MonoBehaviour
{
    public Text confirmText;
    public event Action OnConfirm;
    public event Action OnCancel;
    public event Action<ConfirmationPanel> OnDestroyed;
    [SerializeField] private float xOffset, yOffset;

    private void Start()
    {
        var exists = FindObjectsOfType<ConfirmationPanel>();
        foreach (var confirmation in exists)
        {
            if (confirmation != this && !(confirmation is PhoneEventBehaviour))
            {
                Destroy(confirmation.gameObject);
            }
        }
    }

    public void SetUp(Transform destination, string text)
    {
        transform.position = destination.transform.position + new Vector3(xOffset, yOffset, 0f);
        confirmText.text = text;
    }
    
    public void SetUp(string text)
    {
        confirmText.text = text;
    }

    public virtual void Confirm()
    {
       OnConfirm?.Invoke();
       Destroy(this.gameObject);
    }

    public virtual void Cancel()
    {
        OnCancel?.Invoke();
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }
}
