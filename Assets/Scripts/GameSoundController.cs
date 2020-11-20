using UnityEngine;

[CreateAssetMenu(fileName = "New GameSound Controller", menuName = "Sound/Sound Controller")]
public class GameSoundController : ScriptableObject
{
    public GameSound[] gameSounds;
    
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
        return null;
    }
    
    public void PlayRandomSound()
    {
        var randomSound = Random.Range(0, gameSounds.Length);
        FindObjectOfType<SoundManager>().PlayGameSound(gameSounds[randomSound]);
    }
}
