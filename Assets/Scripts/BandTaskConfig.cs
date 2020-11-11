using UnityEngine;
[CreateAssetMenu(fileName = "NewTask", menuName = "Task")]
public class BandTaskConfig : ScriptableObject
{
    //TODO Add EXP class 
    [SerializeField] private ExperienceAmount[] rewards;
    public int time;
    public int cost;

    /*void Finish(Band band)
    {
        
    }*/
}
