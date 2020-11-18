using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Player player;
    private Image bar;

    private void Start()
    {
        bar = GetComponent<Image>();
        player.OnXPChanged += UpdateBar;
    }

    private void UpdateBar(float value)
    {
        bar.fillAmount = value;
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
