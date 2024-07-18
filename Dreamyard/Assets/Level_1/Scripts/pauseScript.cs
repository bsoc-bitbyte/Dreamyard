using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour
{
    public void setUp()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Level_1");
        Time.timeScale = 1;
    }

    public void ResumeButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
