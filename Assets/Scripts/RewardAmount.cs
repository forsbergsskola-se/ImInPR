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
        return $"{type.name} {amount}";
    }
}