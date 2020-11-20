using UnityEngine;

[CreateAssetMenu(fileName = "NewExp", menuName = "Experience")]
public class Experience : ScriptableObject
{
    public int GetExperience(string bandName)
    {
        return PlayerPrefs.GetInt($"{bandName}.{this.name}", 0);
    }
    
    public void SetExperience(string bandName, int amount)
    {
        var newXp = GetExperience(bandName) + amount;
        PlayerPrefs.SetInt($"{bandName}.{this.name}", newXp);
    }
}