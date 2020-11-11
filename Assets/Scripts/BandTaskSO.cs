using UnityEngine;
[CreateAssetMenu(fileName = "NewTask", menuName = "Task")]
public class BandTaskSO : ScriptableObject
{
    //TODO Add EXP class 
    [SerializeField] private ExperienceAmount[] rewards;
    [SerializeField] private int time;
    [SerializeField] private int cost;
}
