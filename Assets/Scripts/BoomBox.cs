using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class BoomBox : MonoBehaviour
{
    private AudioSource Speakers;
    private int _songIndex;
    
    [SerializeField] private BandList boomBoxPlayList;
    [SerializeField] private GameObject nowPlayingPrefab;

    public bool IsPlaying => Speakers.isPlaying;
    private bool NewSong => Speakers.time == 0;
    public float MusicVolume
    {
        get => PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        set {
                PlayerPrefs.SetFloat("MusicVolume", value);
                Speakers.volume = MusicVolume;
            }
    }

    private int SongIndex
    {
        get => _songIndex;
        set
        {
            if (value < 0)
            {
                _songIndex = boomBoxPlayList.bands.Length - 1;
            }
            else if (value == boomBoxPlayList.bands.Length)
                _songIndex = 0;
            else
                _songIndex = value;
        }
    }

    private void Start() {
        Speakers = GetComponent<AudioSource>();
        Speakers.volume = MusicVolume;
        UpdateTrack();
    }

    public void PreviousTrack()
    {
        var startPlaying = Speakers.isPlaying;
        SongIndex--;
        UpdateTrack();
        if (startPlaying)
        {
            PlayToggle();
            DisplaySong();
        }
    }
    
    public void PlayToggle()
    {
        if (Speakers.isPlaying)
            Speakers.Pause();
        else
        {
            Speakers.UnPause();
            if (NewSong)
            {
                Speakers.Play();
                DisplaySong();
            }
        }
    }

    public void NextTrack()
    {
        var startPlaying = Speakers.isPlaying;
        SongIndex++;
        UpdateTrack();
        if (startPlaying)
        {
            PlayToggle();
            DisplaySong();
        }
    }

    private void DisplaySong()
    {
        var sound = boomBoxPlayList.bands[SongIndex].song;
        var instance = Instantiate(nowPlayingPrefab, this.transform);
        instance.GetComponent<NowPlaying>().Setup(sound.bandName, sound.songName, sound.soundDesignerName);
    }
    
    private void UpdateTrack()
    {
        Speakers.clip = boomBoxPlayList.bands[SongIndex].song.clip;
    }

    /*public void Play(Band band) 
    {
        Play(band.song);
    }
    
    private void Play(GameSong sound)
    {
        if (sound != null)
        {
            if (Speakers.isPlaying)
                Speakers.Stop();
            
            Speakers.clip = sound.clip;
            Speakers.Play();
            var instance = Instantiate(nowPlayingPrefab, this.transform);
            instance.GetComponent<NowPlaying>().Setup(sound.bandName, sound.songName, sound.soundDesignerName);
        }
    }*/
}
