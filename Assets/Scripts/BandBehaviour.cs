using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BandUI))]
public class BandBehaviour : MonoBehaviour
{
    public Band bandConfig;
    public int currentLevel, baseCashGenerated;
    public float generateInterval = 12f;
    [Range(0f, 1f)] public float likelyHoodToGenerateTask;
    public Experience awareness;
    public Experience popularity;
    private float _elapsedTime;

    public void SetUp(Band band)
    {
        bandConfig = band;
        GetComponent<BandUI>().SetUp(band);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime < generateInterval) return;
        FindObjectOfType<GameManager>().cash.Add(baseCashGenerated * currentLevel);
        _elapsedTime -= generateInterval;
        if (Random.Range(0f, 1f) < likelyHoodToGenerateTask)
        {
            GenerateTask();
        }

    }

    void GenerateTask()
    {
        var newTask = FindObjectOfType<GameManager>().taskGenerator.SpawnTask(this);
        if (newTask == null) return;
        newTask.OnRewardCollected += OnReward;
        newTask.OnDestroyed += UnsubscribeFromTask;
    }


    public void OnReward()
    {
        UpdateUI();
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
