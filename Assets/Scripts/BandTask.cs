using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BandTask : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private BandTaskConfig task;
    private string bandName;
    private float time;
    private bool owned;
    private bool finished;
    public event Action OnRewardCollected;
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

        if (time < 0)
        {
            OnTaskComplete?.Invoke();
            finished = true;
        }

        if (!finished) return;
        task.Finish(bandName);
        OnRewardCollected?.Invoke();
        Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!owned)
        {
            owned = true;
            OnTaskStart?.Invoke(); 
        }
        if (!finished) return;
            task.Finish(bandName);
            OnRewardCollected?.Invoke();
            Destroy(gameObject);
    }
}
