using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    private ProgressCircle progressBar;
    public event Action<RewardAmount[]> OnRewardCollected;
    public event Action OnTaskComplete;
    public event Action OnTaskStart;
    public event Action<BandTask> OnDestroyed;
    
    private float ActualTime => time + time * 0.2f * (bandLevel - 1);
    private float ActualFill => ActualTime / task.time;


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
            progressBar.Done();
            progressBar.OnCollect += RewardCollected;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!owned)
        {
            var progressCircles = FindObjectsOfType<ProgressCircle>();
            foreach (var progressCircle in progressCircles)
            {
                if (progressCircle.isUnlocked && !progressCircle.isBeingUsed)
                {
                    progressBar = progressCircle;
                }
            }
            if (progressBar == null || !progressBar.isUnlocked || progressBar.isBeingUsed) return;
            if (FindObjectOfType<GameManager>().cash.Spend(ActualCost()))
            {
                owned = true;
                OnTaskStart?.Invoke();
            }
        }
    }

    void RewardCollected()
    {
        OnRewardCollected?.Invoke(task.rewards);
        progressBar.OnCollect -= RewardCollected;
        progressBar = null;
        Destroy(gameObject);
    }

    int ActualCost()
    {
        return cost + Mathf.RoundToInt(cost * 0.2f) * (bandLevel - 1);
    }

    void UpdateUI()
    {
        GetComponent<TaskUI>().UpdateUI(task.name, task.time, ActualCost().ToString(), task.rewards);
        progressBar.UpdateFill(ActualFill);
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }
}
