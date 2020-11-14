using System;
using UnityEngine;

[RequireComponent(typeof(BandUI))]
public class BandBehaviour : MonoBehaviour
{
    public Band bandConfig;
    public int currentLevel;
    public Experience awareness;
    public Experience popularity;

    private void Start()
    {
        UpdateUI();
    }

    void GenerateTask()
    {
        var newTask = FindObjectOfType<GameManager>().taskGenerator.SpawnTask(this);
        newTask.OnRewardCollected += OnReward;
        newTask.OnDestroyed += UnsubscribeFromTask;
    }


    public void OnReward()
    {
        //TODO UpdateUI here, Do some Visual Effect?
    }
    
    void UpdateUI()
    {
        GetComponent<BandUI>().UpdateUI(currentLevel, 0.7f, 0.7f);
    }
    
    void UnsubscribeFromTask(BandTask task)
    {
        task.OnDestroyed -= UnsubscribeFromTask;
        task.OnRewardCollected -= OnReward;
    }
}
