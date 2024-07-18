using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public void helpMenu()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
