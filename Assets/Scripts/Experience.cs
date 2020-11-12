using UnityEngine;

[CreateAssetMenu(fileName = "NewExp", menuName = "Experience")]
public class Experience : ScriptableObject
{
    public int ExperienceAmount
    {
        get => PlayerPrefs.GetInt(this.name, 0);
        set => PlayerPrefs.SetInt(this.name, value);
    }

    public int GetBandExperience(string bandName)
    {
        return PlayerPrefs.GetInt($"{bandName}.{this.name}", 0);
    }
    
    public void SetBandExperience(string bandName, int amount)
    {
        var newXp = GetBandExperience(bandName) + amount;
        PlayerPrefs.SetInt($"{bandName}.{this.name}", newXp);
    }
}