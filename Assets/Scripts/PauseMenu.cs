using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    private SoundManager soundManager;
    public static bool GameIsPaused; 
    public GameObject pauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
    public void SFXVolume(float volume)
    {
        // TODO Add reference to SFX audio player, add playerprefs, make slider actually change the volume
        soundManager.gameSoundVolume = volume;
    }

    public void MusicVolume(float volume)
    {
        // TODO Add reference to music audio player, add playerprefs, make slider actually change the volume 
        soundManager.musicVolume = volume;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
