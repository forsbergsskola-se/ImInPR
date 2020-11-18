using UnityEngine;
[CreateAssetMenu(fileName = "NewTask", menuName = "Task")]
public class BandTaskConfig : ScriptableObject
{
    public RewardAmount[] rewards;
    public int time;
    public int cost;
    public int tier;
    public int popularity;
    public int awareness;
    public string description;
    public string outComeText;
}