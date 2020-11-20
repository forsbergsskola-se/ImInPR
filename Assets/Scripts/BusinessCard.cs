using System.Collections;
using TMPro;
using UnityEngine;

public class BusinessCard : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private BG background;
    
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI addressText;
    [SerializeField] private TextMeshProUGUI goldPerMinText;
    
    [Header("Player Title (upgrades with Player level)")]
    [SerializeField] private string title1 = "Freelance Promoter";
    [SerializeField] private string title2 = "Junior Promoter";
    [SerializeField] private string title3 = "PR agent";
    [SerializeField] private string title4 = "CEO PR Firm";
    [SerializeField] private string title5 = "Promoter Genius";

    [Header("Player Address (upgrades with Office)")] 
    [SerializeField] private string address1 = "Grandma's Basement";
    [SerializeField] private string address2 = "Suburbia backyard";
    [SerializeField] private string address3 = "Small Townhouse";
    [SerializeField] private string address4 = "3rd floor downtown";
    [SerializeField] private string address5 = "top floor sky scraper";
    private void UpdateLevelText() {
        levelText.SetText(player.Level.ToString());
        StartCoroutine(TextEffect(levelText, Color.magenta, 1f));

    }

    private IEnumerator TextEffect(TextMeshProUGUI textToAffect, Color effectColor, float duration)
    {
        Color startingColor = textToAffect.color;
        Color endColor = effectColor;
       
        float _elapsedtime = 0f;

        while (_elapsedtime < duration)
        {
            textToAffect.color = Color.Lerp(startingColor, endColor, _elapsedtime/duration);
            _elapsedtime += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(ChangeMeBack(textToAffect, startingColor, duration));
    }

    private IEnumerator ChangeMeBack(TextMeshProUGUI text, Color endColor, float duration)
    {
        Color startingColor = text.color;
        Color temp = endColor;
       
        float _elapsedtime = 0f;

        while (_elapsedtime < duration)
        {
            text.color = Color.Lerp(startingColor, temp, _elapsedtime/duration);
            _elapsedtime += Time.deltaTime;
            yield return null;
        }
    }

    private void UpdateJobTitleText()
    {
        string title = "";
        switch (player.Level)
        {
            case 1: title = title1;
                break;
            case 2 : title = title2;
                break;
            case 3: title  = title3;
                break;
            case 4: title = title4;
                break;

            default: title = title5;
                break;
        }
        titleText.SetText(title);
    }

    private void UpdateAddressText()
    {
        string address = "";
        switch (background.Level)
        {
            case 1: address = address1;
                break;
            case 2: address = address2;
                break;
            case 3: address = address3;
                break;
            case 4: address = address4;
                break;
    
            default: address = address5;
                break;
        }
        addressText.SetText(address);
    }

    private void UpdateGoldPerMinText()
    {
        var goldPerMin = GetGoldPerMin();
        goldPerMinText.SetText(goldPerMin.ToString());
    }

    private static int GetGoldPerMin()
    {
        int goldPerMin = 0;
        var temp = FindObjectsOfType<BandBehaviour>();
        foreach (var band in temp)
        {
            goldPerMin += band.MoneyPerMinute;
        }

        return goldPerMin;
    }

    private void Awake(){
        player.OnLevelUp += UpdateLevelText;
        player.OnLevelUp += UpdateJobTitleText;
        background.OnBGChanged += UpdateAddressText;
    }

    private void Start()
    {
        UpdateLevelText();
        UpdateJobTitleText();
        UpdateAddressText();
        InvokeRepeating(nameof(UpdateGoldPerMinText), 1f, 1f);
    }

    private void OnDestroy()
    {
        player.OnLevelUp -= UpdateLevelText;
        player.OnLevelUp -= UpdateJobTitleText;
        background.OnBGChanged -= UpdateAddressText;
    }
}

