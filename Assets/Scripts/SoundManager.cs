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
    [SerializeField] private GameObject nowPlayingPrefab;
    [SerializeField] private Transform parent;
    private GameSong currentSong;
    
    /*public void PlaySound(string soundName)
    {
        var sound = gameSoundController.FindGameAudioClip(soundName);
        Play(sound, gameSoundAudioSource, gameSoundVolume);
    }*/

    public void PlaySong(string songName)
    {
        var sound = (GameSong)musicController.FindGameSound(songName);
        Play(sound, musicAudioSource, musicVolume);
    }

    private void Play(GameSong sound, AudioSource source, float volume)
    {
        if (sound != null)
        {
            if(source.isPlaying)
                source.Stop();
            
            source.PlayOneShot(sound.clip, volume);
            var instance = Instantiate(nowPlayingPrefab, parent);
            instance.GetComponent<NowPlaying>().Setup(sound.bandName, sound.songName, sound.soundDesignerName);
        }
    }
}