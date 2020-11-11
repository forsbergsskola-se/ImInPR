using UnityEngine;

[CreateAssetMenu(fileName = "NewExp", menuName = "Experience")]
public class Experience : ScriptableObject
{
    public int ExperienceAmount
    {
        get => PlayerPrefs.GetInt(this.name, 0);
        set => PlayerPrefs.SetInt(this.name, value);
    }
}