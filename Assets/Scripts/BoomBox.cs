using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(AudioSource))]
public class BoomBox : MonoBehaviour
{
    //private SoundManager _soundManager;
    private AudioSource Speakers;
    private int _songIndex;
    
    [SerializeField] private BandList boomBoxPlayList;
    [SerializeField] private GameObject nowPlayingPrefab;

    public float MusicVolume
    {
        get => PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        set => PlayerPrefs.SetFloat("MusicVolume", value);
    }

    private void Start() => Speakers = GetComponent<AudioSource>();

    public void PreviousTrack()
    {
        Speakers.clip = null;
        LoopTracks();
        Play(boomBoxPlayList.bands[_songIndex]);
        _songIndex--;
    }
    
    public void PlayToggle()
    {
        if(Speakers.isPlaying)
            Speakers.Pause();
        else
        {
            Speakers.UnPause();
            if(!Speakers.isPlaying)
                NextTrack();
        }
    }

    public void NextTrack()
    {
        LoopTracks();
        Play(boomBoxPlayList.bands[_songIndex]);
        _songIndex++;
    }

    private void LoopTracks()
    {
        if (_songIndex <= 0)
            _songIndex = boomBoxPlayList.bands.Length - 1;

        if (_songIndex >= boomBoxPlayList.bands.Length)
            _songIndex = 0;
    }
    
    public void Play(Band band) 
    {
        Play(band.song);
    }
    
    private void Play(GameSong sound)
    {
        if (sound != null)
        {
            if(Speakers.isPlaying)
                Speakers.Stop();

            Speakers.PlayOneShot(sound.clip, MusicVolume);
            var instance = Instantiate(nowPlayingPrefab, this.transform);
            instance.GetComponent<NowPlaying>().Setup(sound.bandName, sound.songName, sound.soundDesignerName);
        }
    }
}
