using UnityEngine;

[System.Serializable]
public class PhoneEventOutcome
{
    public int expAmount;
    public int cashAmount;
    [TextArea] public string message;

    public override string ToString()
    {
        string newString = "Outcome ";
        if (expAmount != 0)
        {
            newString += $"{expAmount} Exp ";
        }
        
        if (cashAmount != 0)
        {
            newString += $"{cashAmount}$";
        }
        return newString;
    }
}
