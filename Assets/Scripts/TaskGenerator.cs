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
    public TaskList allTasks;
    public List<ProgressCircle> progressCircles;
    public GameObject taskPrefab;
    public bool active;
    public TMP_Text message;
    private int MaxAmountOfTasks => Mathf.Clamp(FindObjectOfType<Computer>().Level * 3,3, 10);
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
        newTask.Setup(band.bandConfig.name, GenerateTask(band.CurrentLevel), band.CurrentLevel, this);
        return newTask;
    }

    BandTaskConfig GenerateTask(int level)
    {
        int index;
        do
        {
            index = Random.Range(0, allTasks.tasks.Length);
        } while (level < allTasks.tasks[index].levelRequirement);
        
        return allTasks.tasks[index];
    }

    public void UpdateProgressCircles()
    {
        for (int i = 0; i < FindObjectOfType<Computer>().Level; i++)
        {
            progressCircles[i].isUnlocked = true;
        }
        progressCircles[FindObjectOfType<Computer>().Level - 1].image.fillAmount = 0;
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
