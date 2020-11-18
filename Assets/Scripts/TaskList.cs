using UnityEngine;
[CreateAssetMenu(fileName = "NewTaskList", menuName = "Tasks/Task List")]
public class TaskList : ScriptableObject
{
    public BandTaskConfig[] tasks;
}
