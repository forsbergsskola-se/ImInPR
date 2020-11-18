using UnityEngine;

[CreateAssetMenu(menuName = "Phone Event", fileName = "NewPhoneEvent")]
public class PhoneEvent : ScriptableObject
{
    [TextArea] public string dialogue;
    [Range(1, 5)] [Tooltip("A Level Value Between 1 And 5")] 
    public int level;
    [Range(0, 1)] [Tooltip("A Percentage Value Between 0 And 1")] 
    public float successChance;
    public float time;
    public PhoneEventOutcome negativeOutcome;
    public PhoneEventOutcome positiveOutcome;
    
    public void ApplyPositiveOutcome()
    {
        var gm = FindObjectOfType<GameManager>();
        gm.cash.Add(positiveOutcome.cashAmount);
        FindObjectOfType<Player>().AddXp(positiveOutcome.expAmount);
        var outcomeMessage = Instantiate(gm.OutcomeMessage, gm.transform);
        outcomeMessage.GetComponent<OutcomeMessage>().SetUp(positiveOutcome.message, positiveOutcome.ToString());
    }
    
    public void ApplyNegativeOutcome()
    {
        var gm = FindObjectOfType<GameManager>();
        gm.cash.Add(negativeOutcome.cashAmount);
        FindObjectOfType<Player>().LoseXp(negativeOutcome.expAmount);
        var outcomeMessage = Instantiate(gm.OutcomeMessage, gm.transform);
        outcomeMessage.GetComponent<OutcomeMessage>().SetUp(negativeOutcome.message, negativeOutcome.ToString());
    }

    public override string ToString()
    {
        return $"Chance to succeed; {Mathf.RoundToInt(successChance * 100)}% \n Time away; {time} seconds";
    }
}
