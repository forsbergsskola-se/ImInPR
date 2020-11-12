using UnityEngine;
[CreateAssetMenu(fileName = "NewTask", menuName = "Task")]
public class BandTaskConfig : ScriptableObject
{
    //TODO Add EXP class 
    [SerializeField] private ExperienceAmount[] rewards;
    public int time;
    public int cost;
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