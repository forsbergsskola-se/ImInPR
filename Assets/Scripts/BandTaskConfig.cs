using UnityEngine;
[CreateAssetMenu(fileName = "NewTask", menuName = "Task")]
public class BandTaskConfig : ScriptableObject
{
    public RewardAmount[] rewards;
    public int time;
    public int cost;
    public int tier;
    public string description;
    public string outComeText;

    public void Finish(string bandName)
    {
        foreach (var reward in rewards)
        {
            reward.ApplyReward(bandName);
        }
    }
}