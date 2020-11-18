[System.Serializable]
public struct RewardAmount
{
    public Experience type;
    public int amount;

    public void ApplyReward(string bandName)
    {
        type.SetExperience(bandName, amount);
    }

    public override string ToString()
    {
        return $"{type.name.ToCharArray()[0]}{AmountOfPluses(amount)}";
    }

    string AmountOfPluses(int value)
    {
        switch (value)
        {
            case 20: return "+";
            case 40: return "++";
            case 60: return "+++";
        }

        return "+";
    }
}