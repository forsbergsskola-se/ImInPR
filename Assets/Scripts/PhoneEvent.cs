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
        //TODO Connect This To Player API To Apply Exp As Well
    }
    
    public void ApplyNegativeOutcome()
    {
        var gm = FindObjectOfType<GameManager>();
        gm.cash.Add(negativeOutcome.cashAmount);
        //TODO Connect This To Player API To Apply Exp As Well
    }
}
