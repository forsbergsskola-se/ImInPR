using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TaskGenerator : MonoBehaviour
{
    public List<BandTaskConfig> allTasks;
    public GameObject taskPrefab;
    public bool active;
    private int MaxAmountOfTasks => FindObjectOfType<Computer>().Level * 3;
    private bool CanGenerateTask => GetComponentsInChildren<BandTask>().Length < MaxAmountOfTasks;
    

    public bool CanActivateTask
    {
        get
        {
            var activeTasks = GetComponentsInChildren<BandTask>().Count(tasks => tasks._taskState == TaskState.Active || tasks._taskState == TaskState.Done);
            return FindObjectOfType<Computer>().Level > activeTasks;
        }
    }

    public BandTask SpawnTask(BandBehaviour band)
    {
        if (!CanGenerateTask) return default;
        var instance = Instantiate(taskPrefab, this.transform);
        var newTask = instance.GetComponentInChildren<BandTask>();
        newTask.Setup(band.bandConfig.name, GenerateTask(band.currentLevel), band.currentLevel, this);
        return newTask;
    }

    BandTaskConfig GenerateTask(int level)
    {
        int index;
        do
        {
            index = Random.Range(0, allTasks.Count);
        } while (level < allTasks[index].tier);
        
        return allTasks[index];
    }
    [ContextMenu("ToggleTaskList")]
    public void ToggleGraphics()
    {
        var myList = new List<Behaviour>();
        myList.AddRange(GetComponentsInChildren<Image>());
        myList.AddRange(GetComponentsInChildren<Text>());
        myList.AddRange(GetComponentsInChildren<TMP_Text>());
        foreach (var image in myList)
        {
            image.enabled = !active;
        }
        active = !active;
    }
}
