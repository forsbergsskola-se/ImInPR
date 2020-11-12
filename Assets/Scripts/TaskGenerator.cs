using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TaskGenerator : MonoBehaviour
{
    List<BandTask> currentlyActiveTasks = new List<BandTask>();
    public List<BandTaskConfig> allTasks;
    public BandTask taskPrefab;

    private void Start()
    {
        SpawnTask();
    }

    //TODO get band as a parameter here
    void SpawnTask()
    {
        string name = "EBBA";
        int lvl = 12;
        
        var newBand = Instantiate(taskPrefab, this.transform);
        currentlyActiveTasks.Add(newBand);
        newBand.GetComponent<BandTask>().Setup(name, GenerateTask(lvl)); 
        //newBand.OnRewardCollected += band.AwaitReward;
    }

    BandTaskConfig GenerateTask(int tier)
    {
        var index = 0;
        do
        {
            index = Random.Range(0, allTasks.Count);
        } while (tier / 3 < allTasks[index].tier);
        
        return allTasks[index];
    }
}
