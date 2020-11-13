using System;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationPanel : MonoBehaviour
{
    public Text confirmText;
    public event Action OnAccept;
    public event Action OnDecline;
    [SerializeField] private float xOffset, yOffset;

    private void Start()
    {
        var exists = FindObjectsOfType<ConfirmationPanel>();
        foreach (var confirmation in exists)
        {
            if (confirmation != this)
            {
                Destroy(confirmation.gameObject);
            }
        }
    }

    public void SetUpOfficeUpgradeable(Transform destination, OfficeInteractable officeObject)
    {
        //TODO Make UI Match The OfficeObjects Information
        //this.parent.position = parent.position;
        confirmText.text = UpgradeString(officeObject.name);
    }

    public void SetUp(Transform destination, BandTask task) => confirmText.text = task.task.description;

    public void SetUp(Transform destination, String text)
    {
        transform.position = destination.transform.position + new Vector3(xOffset, yOffset, 0f);
        confirmText.text = text;
    }

    public void Accept() => OnAccept?.Invoke();

    public void Decline() => OnDecline?.Invoke();

    //todo
    public string UpgradeString(string objectName)
    {
        return $"You are about to upgrade {objectName} \n" +
               "Are you sure you would like to upgrade this?";
    }
}
