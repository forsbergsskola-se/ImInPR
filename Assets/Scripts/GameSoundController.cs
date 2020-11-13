using UnityEngine;

[CreateAssetMenu(fileName = "New GameSound Controller", menuName = "Sound/Sound Controller")]
public class GameSoundController : ScriptableObject
{
    [SerializeField] private GameSound[] gameSounds;
    
    public AudioClip FindGameAudioClip(string value)
    {
        var sound = FindGameSound(value);
        if (sound != null)
        {
            return sound.clip;
        }
        Debug.Log($"Sound clip {value} not found...");
        return null;
    }

    public GameSound FindGameSound(string value)
    {
        foreach (var gameSound in gameSounds)
        {
            if (gameSound.name.ToLower() == value.ToLower())
            {
                return gameSound;
            }
        }
        Debug.Log($"GameSound {value} not found");
        return null;
    }
}
