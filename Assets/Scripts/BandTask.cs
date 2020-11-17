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
    private int bandLevel;
    public event Action<RewardAmount[]> OnRewardCollected;
    public event Action OnTaskComplete;
    public event Action OnTaskStart;
    public event Action<BandTask> OnDestroyed;


    public void Setup(string bandName, BandTaskConfig task, int bandLevel)
    {
        this.bandName = bandName;
        this.bandLevel = bandLevel;
        this.task = task;
        time = task.time;
        cost = task.cost;
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
            if (FindObjectOfType<GameManager>().cash.Spend(ActualCost()))
            {
                
                owned = true;
                OnTaskStart?.Invoke();
            }
        }
        if (!finished) return;
            OnRewardCollected?.Invoke(task.rewards);
            Destroy(gameObject);
    }

    int ActualCost()
    {
        return cost + Mathf.RoundToInt(cost * 0.2f) * (bandLevel - 1);
    }
    
    float ActualTime()
    {
        return time + time * 0.2f * (bandLevel - 1);
    }

    void UpdateUI()
    {
        GetComponent<TaskUI>().UpdateUI(task.name, task.time, ActualCost().ToString(), task.rewards, ActualTime());
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }
}
