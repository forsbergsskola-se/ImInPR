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
    //[SerializeField] private Transform parent;
    private GameSong _currentSong;
    
    public void PlaySong(string songName)
    {
        var sound = (GameSong)musicController.FindGameSound(songName);
        PlayMusic(sound, musicAudioSource, musicVolume);
    }

    private void PlayMusic(GameSong sound, AudioSource source, float volume)
    {
        if (sound != null)
        {
            if(source.isPlaying)
                source.Stop();
            
            Play(sound, source, volume);
            var instance = Instantiate(nowPlayingPrefab, this.transform);
            instance.GetComponent<NowPlaying>().Setup(sound.bandName, sound.songName, sound.soundDesignerName);
        }
    }
    private void Play(GameSound sound, AudioSource source, float volume)
    {
        source.PlayOneShot(sound.clip, volume);
    }

    
}