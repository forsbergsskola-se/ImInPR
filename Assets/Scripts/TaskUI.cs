using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TaskUI : MonoBehaviour
{
    public TMP_Text taskName, outcome, timeCost, bandName, taskLevel;
    public Image progressBar;
    public Color[] colors;
    public Image clickArea;
    public void UpdateUI(int state)
    {
        clickArea.color = colors[state];
    }
    
    public void SetUpUI(BandTaskConfig taskConfig, float taskTime, string bandName, string cost, RewardAmount[] outcomes, int state, bool onComputer)
    {
        this.taskName.text = taskConfig.name;
        this.timeCost.text = $"Time {taskTime} | Cost {cost}";
        this.bandName.text = bandName;
        this.taskLevel.text = taskConfig.levelRequirement.ToString();
        foreach (var outcome in outcomes)
        {
            this.outcome.text += outcome + "\n";
        }
        clickArea.color = colors[state];
        if (!onComputer)
        {
            var myList = new List<Behaviour>();
            myList.AddRange(GetComponentsInChildren<Image>());
            myList.AddRange(GetComponentsInChildren<Text>());
            myList.AddRange(GetComponentsInChildren<TMP_Text>());
            foreach (var image in myList)
            {
                image.enabled = !image.enabled;
            }
        }
    }
}
