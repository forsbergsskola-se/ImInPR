using UnityEngine;
[CreateAssetMenu(fileName = "NewTask", menuName = "Tasks/Task")]
public class BandTaskConfig : ScriptableObject
{
    public RewardAmount[] rewards;
    public int time;
    public int cost;
    public int levelRequirement;
    public string description;
    public string outComeText;
}