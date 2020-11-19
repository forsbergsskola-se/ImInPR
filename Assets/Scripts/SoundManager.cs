using System;
using System.Collections;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    [Header("Game Sounds")]
    [SerializeField] public AudioSource gameSoundAudioSource;
    [SerializeField] private GameSoundController gameSoundController;

    [Header("Background Music")] 
    [SerializeField] private AudioSource backgroundMusicPlayer;
    [SerializeField] private GameSound idleMusic;

    private void Start() => playBackgroundMusic();

    public float BackgroundMusicVolume
    {
        get => PlayerPrefs.GetFloat("BackGroundVolume", 0.3f);
        set
        {
            PlayerPrefs.SetFloat("BackGroundVolume", value);
            backgroundMusicPlayer.volume = BackgroundMusicVolume;
        }
    }

    public float GameSoundVolume
    {
        get => PlayerPrefs.GetFloat("GameSoundVolume", 0.5f);
        set => PlayerPrefs.SetFloat("GameSoundVolume", value);
    }

    #region GameSound Player

    public void PlayGameSound(GameSound sound)
    {
        Play(sound, gameSoundAudioSource, GameSoundVolume);
    }
    
    public void PlayGameSound(string soundName)
    {
        Play(gameSoundController.FindGameSound(soundName), gameSoundAudioSource, GameSoundVolume);
    }

    private void Play(GameSound sound, AudioSource source, float volume)
    {
        if (backgroundMusicPlayer.isPlaying)
        {
            backgroundMusicPlayer.Pause();
        }
            
        source.PlayOneShot(sound.clip, volume);
    }
    #endregion

    #region backgroundMusic
    public void playBackgroundMusic()
    {
        backgroundMusicPlayer.loop = true;
        backgroundMusicPlayer.clip = idleMusic.clip;
        backgroundMusicPlayer.volume = BackgroundMusicVolume;
        backgroundMusicPlayer.Play();
    }
    #endregion
}