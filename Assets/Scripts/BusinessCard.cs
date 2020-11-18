using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BusinessCard : MonoBehaviour
{
    [SerializeField] private Player player;
    
    public Image logo;
    [SerializeField] private Sprite notification; 
    [SerializeField] private TextMeshProUGUI playerHeader;
    [SerializeField] private TextMeshProUGUI playerLevelText;
    [SerializeField] private TextMeshProUGUI playerTitleText;
    [SerializeField] private Image xpBar;
    
    private void updateXpBar(float start, float end)
    {
        float elapsedTime = 0;
        float timeToComplete = 1f;
        
        while (elapsedTime < timeToComplete)
        {
            elapsedTime += Time.deltaTime;
            xpBar.fillAmount = Mathf.Lerp(start, end, elapsedTime);
        }
    }

    public void XPChanged()
    {
        //updateXpBar(playerXP.ExperienceAmount, playerXP.ExperienceAmount + value);
    }
    public void UpdateLevelText() => playerLevelText.SetText(player.Level.ToString());

    private void Awake() => player.OnLevelUp += UpdateLevelText;

    private void Start()
    {
        UpdateLevelText();
    }

    private void OnDestroy() => player.OnLevelUp -= UpdateLevelText;
}

