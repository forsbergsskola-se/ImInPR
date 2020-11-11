using System;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameSoundController gameSoundController;

    private AudioSource _audioSource;
    [Range(0,1f)]
    public float volume = 1f;
    private void Start()
    {
        _audioSource = FindObjectOfType<AudioSource>();
    }

    public void PlaySound(string name)
    {
        var sound = gameSoundController.FindGameSound(name);

        if (sound != null)
        {
            _audioSource.PlayOneShot(sound, volume);
        
            Debug.Log($"playing GameSound : {sound.name}");
        }
    }
}