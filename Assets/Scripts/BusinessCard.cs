﻿using System;
using TMPro;
using UnityEngine;

public class BusinessCard : MonoBehaviour
{
    [SerializeField] private Player player;
    
    public Sprite logo;
    public Sprite notification; 
    [SerializeField] private TextMeshProUGUI playerHeader;
    [SerializeField] private TextMeshProUGUI playerLevelText;
    [SerializeField] private TextMeshProUGUI playerTitleText;
    
    //[SerializeField] private ProgressBar XpBar;

    public void UpdateLevelText() => playerLevelText.SetText(player.Level.ToString());

    private void Start() => player.OnLevelUp += UpdateLevelText;
    private void OnDestroy() => player.OnLevelUp -= UpdateLevelText;
}
