using TMPro;
using UnityEngine;

/*Next row is depending on Player Level
Level 1: Freelance Promoter
Level 2: Junior Promotor
Level 3: PR agent
Level 4: CEO PR Firm
Level 5: Promotor Genius*/

public class BusinessCard : MonoBehaviour
{
    [SerializeField] private Player player;
    
    [SerializeField] private TextMeshProUGUI playerHeader;
    [SerializeField] private TextMeshProUGUI playerLevelText;
    [SerializeField] private TextMeshProUGUI playerTitleText;
    
    public void UpdateLevelText() => playerLevelText.SetText(player.Level.ToString());

    private void Awake() => player.OnLevelUp += UpdateLevelText;

    private void Start()
    {
        UpdateLevelText();
    }

    private void OnDestroy() => player.OnLevelUp -= UpdateLevelText;
}

