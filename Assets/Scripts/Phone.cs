using UnityEngine;
using UnityEngine.EventSystems;

public class Phone : OfficeInteractable
{
    private bool _isCalling;
    private GameObject _callPanel;
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (_isCalling)
        {
            _isCalling = false;
            _callPanel.SetActive(true);
        }
        else base.OnPointerClick(eventData);
    }

    public void IncomingCall(GameObject callPanel)
    {
        _isCalling = true;
        _callPanel = callPanel;
        Debug.Log("Call Incoming");
        //TODO Spawn Exclamation Mark
    }
}
