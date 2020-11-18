using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Slider slider;

    private void Start()
    {
        //bar = GetComponent<Image>();
        player.OnXPChanged += UpdateBar;
        UpdateBar(player.XpPercentage());
    }

    public void UpdateBar(float value)
    {
        slider.value = value;
    }

    public void SetMax(float value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

    private void OnDestroy()
    {
        player.OnXPChanged -= UpdateBar;
    }
    
    /*private void UpdateXpBar(float start, float end)
    {
        float elapsedTime = 0;
        float timeToComplete = 1f;
        
        while (elapsedTime < timeToComplete)
        {
            elapsedTime += Time.deltaTime;
            xpBar.fillAmount = Mathf.Lerp(start, end, elapsedTime);
        }
    }
      
     */
}
