using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BandTask : MonoBehaviour, IPointerClickHandler
{
    public BandTaskConfig task;
    private string bandName;
    private float time, startTime;
    private int cost;
    public TaskState _taskState = TaskState.Inactive;
    private int bandLevel;
    private ProgressCircle progressBar;
    private TaskGenerator _taskGenerator;
    public event Action<RewardAmount[]> OnRewardCollected;
    public event Action OnTaskComplete;
    public event Action OnTaskStart;
    public event Action<BandTask> OnDestroyed;
    
    private float ActualTime => startTime + startTime * 0.2f * (bandLevel);
    private float ActualFill => time / ActualTime;


    public void Setup(string bandName, BandTaskConfig task, int bandLevel, TaskGenerator taskGenerator)
    {
        this.bandName = bandName;
        this.bandLevel = bandLevel;
        this.task = task;
        cost = task.cost;
        startTime = task.time;
        _taskGenerator = taskGenerator;
        SetUpUI();
    }

    private void Update()
    {
        if (_taskState == TaskState.Active)
        {
            time += Time.deltaTime;
            UpdateUI();
        }

        if (time >= ActualTime)
        {
            OnTaskComplete?.Invoke();
            _taskState = TaskState.Done;
            progressBar.Done();
            UpdateUI();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_taskState != TaskState.Active && _taskGenerator.CanActivateTask)
        {
            if (FindObjectOfType<GameManager>().cash.Spend(ActualCost()))
            {
                OnTaskStart?.Invoke();
                _taskState = TaskState.Active;
                var progressCircles = FindObjectsOfType<ProgressCircle>();
                foreach (var progressCircle in progressCircles)
                {
                    if (progressCircle.isUnlocked && !progressCircle.isBeingUsed)
                    { 
                        progressBar = progressCircle;
                        Debug.Log("There's an available circle");
                        progressBar.isBeingUsed = true;
                        progressCircle.OnCollect += RewardCollected;
                    }
                }
                UpdateUI();
            }
        }

        if (_taskState == TaskState.Done)
        {
            progressBar.OnPointerClick(eventData);
            //RewardCollected();
        }
    }

    void RewardCollected(ProgressCircle circle)
    {
        circle.OnCollect -= this.RewardCollected;
        OnRewardCollected?.Invoke(task.rewards);
        progressBar = null;
        Destroy(GetComponentInParent<TaskUI>().gameObject);
    }

    int ActualCost()
    {
        return cost + Mathf.RoundToInt(cost * 0.2f) * (bandLevel - 1);
    }

    void SetUpUI()
    {
        GetComponentInParent<TaskUI>().SetUpUI(task, ActualTime, bandName,ActualCost().ToString(), task.rewards, (int)_taskState, _taskGenerator.active);
    }

    void UpdateUI()
    {
        GetComponentInParent<TaskUI>().UpdateUI((int)_taskState);
        progressBar.UpdateFill(ActualFill);
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }
}

public enum TaskState
{
    Inactive = 0,
    Active = 1,
    Done = 2
}
