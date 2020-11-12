using System;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    [Header("Game Sounds")]
    [SerializeField] private AudioSource gameSoundAudioSource;
    [SerializeField] private GameSoundController gameSoundController;
    [Range(0,1f)]public float gameSoundVolume = 0.5f;
    
    [Header("Game Music")]
    [SerializeField] private AudioSource musicAudioSource;
    [SerializeField] private GameSoundController musicController;
    [Range(0,1f)] public float musicVolume = 0.5f;
    
    public void PlaySound(string soundName)
    {
        var sound = gameSoundController.FindGameSound(soundName);
        Play(sound, gameSoundAudioSource, gameSoundVolume);
    }

    public void PlaySong(string songName)
    {
        var sound = musicController.FindGameSound(songName);
        Play(sound, musicAudioSource, musicVolume);
    }

    private void Play(AudioClip clip, AudioSource source, float volume)
    {
        if (clip != null)
        {
            if(source.isPlaying)
                source.Stop();
            
            source.PlayOneShot(clip, volume);
            Debug.Log($"playing GameSound : {clip.name}");
        }
    }
}