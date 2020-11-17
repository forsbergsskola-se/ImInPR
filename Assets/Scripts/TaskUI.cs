using UnityEngine.UI;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(BandTask))]
public class TaskUI : MonoBehaviour
{
    public TMP_Text taskName, outcome, timeCost;
    public Image progressBar;
    public void UpdateUI(string taskName, float time, string cost, RewardAmount[] outcomes)
    {
        this.taskName.text = taskName;
        this.timeCost.text = $"Time {time} | Cost {cost}";
        this.outcome.text = "";
        foreach (var outcome in outcomes)
        {
            this.outcome.text += outcome + "\n";
        }
    }
}
