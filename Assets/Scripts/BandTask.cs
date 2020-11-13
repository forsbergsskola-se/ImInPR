using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TaskUI))]
public class BandTask : MonoBehaviour, IPointerClickHandler
{
    public BandTaskConfig task;
    private string bandName;
    private float time;
    private int cost;
    private bool owned;
    private bool finished;
    public event Action OnRewardCollected;
    public event Action OnTaskComplete;
    public event Action OnTaskStart;

    //TODO implement band class
    public void Setup(string bandName, BandTaskConfig task)
    {
        this.bandName = bandName;
        this.task = task;
        time = task.time;
        UpdateUI();
    }

    private void Update()
    {
        if (owned)
        {
            time -= Time.deltaTime;
            UpdateUI();
        }

        if (time < 0)
        {
            OnTaskComplete?.Invoke();
            finished = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!owned)
        {
            if (FindObjectOfType<GameManager>().cash.Spend(cost))
            {
                
                owned = true;
                OnTaskStart?.Invoke();
            }
        }
        if (!finished) return;
            task.Finish(bandName);
            OnRewardCollected?.Invoke();
            Destroy(gameObject);
    }

    void UpdateUI()
    {
        GetComponent<TaskUI>().UpdateUI(task.name, task.time, task.cost.ToString(), task.rewards, time);
    }
}
