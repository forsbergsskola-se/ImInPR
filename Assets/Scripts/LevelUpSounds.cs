using UnityEngine;

public class LevelUpSounds : MonoBehaviour
{
    public GameSoundController soundController;

    public void PlayRandomSound()
    {
        var randomSound = Random.Range(0, soundController.gameSounds.Length);
        FindObjectOfType<SoundManager>().PlayGameSound(soundController.gameSounds[randomSound]);
    }
}
