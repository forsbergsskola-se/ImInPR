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
        // TODO add playerprefs, make slider actually change the volume
        soundManager.gameSoundVolume = volume;
    }

    public void MusicVolume(float volume)
    {
        // TODO add playerprefs, make slider actually change the volume 
        soundManager.musicVolume = volume;
    }

    public void Quit()
    {
        //If we are running in a standalone build of the game
        #if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
        #endif
 
        //If we are running in the editor
        #if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
