[System.Serializable]
public struct ExperienceAmount
{
    public Experience type;
    public int amount;

    public void ApplyReward(string bandName)
    {
        type.SetBandExperience(bandName, amount);
    }
}