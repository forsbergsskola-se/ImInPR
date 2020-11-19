using UnityEngine;
using UnityEngine.EventSystems;

public class Phone : OfficeInteractable
{
    private bool _isCalling;
    private GameObject _callPanel;
    public GameObject ExclamationMarkPrefab;
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (_isCalling)
        {
            _isCalling = false;
            _callPanel.SetActive(true);
            ExclamationMarkPrefab.SetActive(false);
        }
        else base.OnPointerClick(eventData);
    }

    public void IncomingCall(GameObject callPanel)
    {
        _isCalling = true;
        _callPanel = callPanel;
        ExclamationMarkPrefab.SetActive(true);
    }
}
