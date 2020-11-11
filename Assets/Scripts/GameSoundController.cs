using UnityEngine;

[CreateAssetMenu(fileName = "New GameSound Controller", menuName = "Sound/Sound Controller")]
public class GameSoundController : ScriptableObject
{
    [SerializeField] private GameSound[] gameSounds;
    
    public AudioClip FindGameSound(string name)
    {
        foreach (var gameSound in gameSounds)
        {
            if (gameSound.name.ToLower() == name.ToLower())
            {
                return gameSound.clip;
            }
        }
        Debug.Log($"Sound clip {name} not found...");
        return null;
    }
}
