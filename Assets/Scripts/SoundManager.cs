using UnityEngine;
public class SoundManager : MonoBehaviour
{
    [Header("Game Sounds")]
    [SerializeField] public AudioSource gameSoundAudioSource;
    [SerializeField] private GameSoundController gameSoundController;
    [Range(0,1f)]public float gameSoundVolume = 0.5f;
    
    [Header("Game Music")]
    [SerializeField] public AudioSource musicAudioSource;
    [SerializeField] private GameSoundController musicController;
    [Range(0,1f)] public float musicVolume = 0.5f;
    [SerializeField] private GameObject nowPlayingPrefab;
    

    #region GameSound Player
    private void Play(GameSound sound, AudioSource source, float volume) => source.PlayOneShot(sound.clip, volume);
    
    #endregion
    
    
    #region Music Player
    public void PlayMusic(Band band) 
    {
        PlayMusic(band.song, musicVolume);
    }
    
    public void PlayMusic(string songName)
    {
        var sound = (GameSong)musicController.FindGameSound(songName);
        PlayMusic(sound, musicVolume);
    }
    
    private void PlayMusic(GameSong sound, float volume)
    {
        if (sound != null)
        {
            if(musicAudioSource.isPlaying)
                musicAudioSource.Stop();
            
            Play(sound, musicAudioSource, volume);
            var instance = Instantiate(nowPlayingPrefab, this.transform);
            instance.GetComponent<NowPlaying>().Setup(sound.bandName, sound.songName, sound.soundDesignerName);
        }
    }

    public void PauseToggleMusic()
    {
        if(musicAudioSource.isPlaying)
            musicAudioSource.Pause();
        else
            musicAudioSource.UnPause();
    }
    #endregion
}