using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PLAY : MonoBehaviour
{
    public static bool easy=true;
    // Start is called before the first frame update
    public void PlayEasy()
    {
        easy = true;
        SceneManager.LoadScene(3);

    }
    public void PlayHard()
    {
        easy = false;
        SceneManager.LoadScene(3);

    }

}
