using TMPro;
using UnityEngine;

/* Next row is adress based on office level (room level)
[00:55]
office 1: Grandma's Basement
[00:56]
Office 2: Suburbia backyard
[00:59]
Office 3: Small Townhouse
[01:00]
office 4: 3rd floor downtown
[01:00]
office 5: top floor sky scraper*/
public class BusinessCard : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private BG background;
    
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI addressText;
    
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
    private void UpdateLevelText() => levelText.SetText(player.Level.ToString());

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
    }

    private void OnDestroy()
    {
        player.OnLevelUp -= UpdateLevelText;
        player.OnLevelUp -= UpdateJobTitleText;
        background.OnBGChanged -= UpdateAddressText;
    }
}

