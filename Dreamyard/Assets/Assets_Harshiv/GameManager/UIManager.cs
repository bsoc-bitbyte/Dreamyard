using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private float gameOverSoundVolume = 0.5f;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    private List<AudioSource> audioSources;

    private void Awake()
    {
        audioSources = new List<AudioSource>(FindObjectsOfType<AudioSource>());
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound, gameOverSoundVolume);
        foreach (AudioSource source in audioSources)
        {
            if (source != null && source != SoundManager.instance.GetComponent<AudioSource>())
            {
                source.enabled = false;
            }
        }
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        foreach (AudioSource source in audioSources)
        {
            if (source != null)
            {
                source.enabled = true;
            }
        }
        SceneManager.LoadScene("lvl5_Scene1");
    }

    public void MainMenu()
    {
        foreach (AudioSource source in audioSources)
        {
            if (source != null)
            {
                source.enabled = true;
            }
        }
        SceneManager.LoadScene("_lvl5_MainMenu");
    }

    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy)
            {
                PauseGame(false);
            }
            else
            {
                PauseGame(true);
            }
        }
    }


    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);

        if(status)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        
    
    }

    

} 

