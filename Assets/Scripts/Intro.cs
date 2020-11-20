using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public float elapsedTime;
    public GameObject helpMenu;
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadScene();
        }
        
        if (elapsedTime < videoPlayer.length) return;
        
        if (!videoPlayer.isPlaying)
        {
            helpMenu.SetActive(true);
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
