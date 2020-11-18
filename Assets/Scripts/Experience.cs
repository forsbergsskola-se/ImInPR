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
    
    // Tested some math functions
    /*public float GetPercentageOfLevelBar(string bandName, int baseAmountToLevel)
    {
        var totalExp = GetExperience(name);
        var lvl = GetLevel(bandName, baseAmountToLevel);
        var xpUntilNextLvl = GetNextAmountOfXp(bandName, baseAmountToLevel) - GetExperience(bandName);
        return (float) xpUntilNextLvl / GetExperience(bandName);
    }

    public int GetLevel(string bandName, int baseAmountToLevel)
    {
        return Mathf.FloorToInt(Mathf.Log(1.1f, GetExperience(bandName) + baseAmountToLevel / GetExperience(bandName)));
    }

    public int GetNextAmountOfXp(string bandName, int baseAmountToLevel)
    {
        var currentLvl = GetLevel(bandName, baseAmountToLevel);
        return Mathf.RoundToInt(baseAmountToLevel * currentLvl + Mathf.Pow(1.1f, currentLvl));
    }*/
}