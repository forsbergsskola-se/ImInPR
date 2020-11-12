using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BandTask : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private BandTaskConfig task;
    private string bandName;
    private float time;
    private bool owned;
    public event Action OnTaskComplete;
    public event Action OnTaskStart;

    //TODO implement band class
    BandTask Setup(string bandName)
    {
        this.bandName = bandName;
        time = task.time;
        owned = true;
        return this;
    }

    private void Update()
    {
        if (owned)
        {
            time -= Time.deltaTime;
        }

        if (!(time < 0)) return;
        task.Finish(bandName);
        OnTaskComplete?.Invoke();
        Destroy(this.gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        owned = true;
        OnTaskStart?.Invoke();
    }
}
