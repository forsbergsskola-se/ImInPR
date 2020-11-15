using UnityEngine;

[CreateAssetMenu(menuName = "Phone Event", fileName = "NewPhoneEvent")]
public class PhoneEvent : ScriptableObject
{
    [TextArea] public string dialogue;
    [TextArea] public string negativeOutcomeMessage;
    [TextArea] public string positiveOutcomeMessage;
    public int level;
    [Range(0, 1)] [Tooltip("A Percentage Value Between 0 And 1")] 
    public float successChance;
    public float time;
}
