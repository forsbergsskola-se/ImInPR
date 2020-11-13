[System.Serializable]
public struct ExperienceAmount
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