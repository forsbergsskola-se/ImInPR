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
    private int maxAmountOfTasks = 3;
    
    public BandTask SpawnTask(BandBehaviour band)
    {
        if (currentlyActiveTasks.Count >= maxAmountOfTasks) return default;
        var newTask = Instantiate(taskPrefab, this.transform);
        currentlyActiveTasks.Add(newTask);
        newTask.GetComponent<BandTask>().Setup(band.bandConfig.name, GenerateTask(band.currentLevel), band.currentLevel);
        return newTask;
    }

    BandTaskConfig GenerateTask(int level)
    {
        var index = 0;
        do
        {
            index = Random.Range(0, allTasks.Count);
        } while (level < allTasks[index].tier);
        
        return allTasks[index];
    }
}
