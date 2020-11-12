using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TaskGenerator : MonoBehaviour
{
    List<BandTask> currentlyActiveTasks;
    public List<BandTaskConfig> allTasks;
    public BandTask taskPrefab;

    /*void SpawnTask(Band band)
    {
        var newBand = Instantiate(taskPrefab);
        currentlyActiveTasks.Add(newBand);
        newBand.GetComponent<BandTask>().Setup(band.Name, GenerateTask(band.lvl)); 
        newBand.OnRewardCollected += band.AwaitReward;
    }*/

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
