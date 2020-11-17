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
    
    //[SerializeField] private ProgressBar XpBar;

    public void UpdateLevelText() => playerLevelText.SetText(player.Level.ToString());

    private void Awake() => player.OnLevelUp += UpdateLevelText;
    private void OnDestroy() => player.OnLevelUp -= UpdateLevelText;
}
