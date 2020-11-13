using UnityEngine;
using UnityEngine.EventSystems;

public class BoomBox : OfficeInteractable
{
    private SoundManager _soundManager;
    [SerializeField] private BandList boomBoxPlayList;
    
    private int _songIndex;
    
    private void Start() => _soundManager = FindObjectOfType<SoundManager>();

    public override void OnPointerClick(PointerEventData eventData)
    {
        //FindObjectOfType<SoundManager>().PlaySong("80Funk");
        NextTrack();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            PreviousTrack();
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            _soundManager.PauseToggleMusic();
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            NextTrack();
        }
    }

    private void PreviousTrack()
    {
        LoopTracks();
        _soundManager.PlayMusic(boomBoxPlayList.bands[_songIndex]);
        _songIndex--;
    }

    private void NextTrack()
    {
        LoopTracks();
        _soundManager.PlayMusic(boomBoxPlayList.bands[_songIndex]);
        _songIndex++;
    }
    
    private void LoopTracks()
    {
        if (_songIndex <= 0)
            _songIndex = boomBoxPlayList.bands.Length - 1;

        if (_songIndex >= boomBoxPlayList.bands.Length)
            _songIndex = 0;
    }
}
