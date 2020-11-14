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
    
    public BandTask SpawnTask(BandBehaviour band)
    {
        var newTask = Instantiate(taskPrefab, this.transform);
        currentlyActiveTasks.Add(newTask);
        newTask.GetComponent<BandTask>().Setup(band.bandConfig.name, GenerateTask(band.currentLevel));
        return newTask;
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
