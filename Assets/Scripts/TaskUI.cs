using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TaskUI : MonoBehaviour
{
    public TMP_Text taskName, outcome, timeCost;
    public Image progressBar;
    public void UpdateUI(string taskName, float time, string cost, ExperienceAmount[] outcomes, float currentTime)
    {
        this.taskName.text = taskName;
        this.timeCost.text = $"Time {time} | Cost {cost}";
        this.outcome.text = "";
        foreach (var outcome in outcomes)
        {
            this.outcome.text += outcome + "\n";
        }

        var transform1 = progressBar.transform;
        var barScale = transform1.localScale;
        barScale.x = currentTime / time;
        transform1.localScale = barScale;
    }
}
