using UnityEngine;
public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameSoundController gameSoundController;
    
    public void PlaySound(string name)
    {
        var sound = gameSoundController.FindGameSound(name);
        Debug.Log(sound);
    }
}