using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text pointText;
    public Text deathText;
    public Text timeText;
    public Text damageText;
    public Text cointText;
    public Text GameOverText;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    public void Setup(int coin, int death, int damage, int time)
    {
        gameObject.SetActive(true);
        //audioManager.PlaySFX(audioManager.GameOver);
        audioManager.musicSource.clip = null;
        Time.timeScale = 0;
        cointText.text = "Coins Collected : " + coin.ToString();
        int totalScore = coin * 10 - death * 10;
        if(totalScore < 0) totalScore = 0;
        if (totalScore <= 40) GameOverText.text = "Level Failed";
        else GameOverText.text = "Level Completed";
        pointText.text = "Total Score : " + totalScore.ToString();
        deathText.text = "Death : " + death.ToString();
        damageText.text = "Damage Taken : " + damage.ToString();
        timeText.text = "Time Taken : " + time.ToString();
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level_1");
    }

    public void ExitButton()
    {
        audioManager.musicSource.clip = audioManager.background;
        Time.timeScale = 1;
    }
}
