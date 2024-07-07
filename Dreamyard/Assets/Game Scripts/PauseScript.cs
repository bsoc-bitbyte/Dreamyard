using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{   
    public GameObject PauseMenu;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused){
                ResumeGame();
                isPaused  = !isPaused;
            }

            else{
                PauseGame();
                isPaused = !isPaused;
            }
        }

    }

    public void PauseGame(){
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame(){
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ResetLevel(){
        ResumeGame();
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void MainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        ResumeGame();
    }

    public void SettingsMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("SettingsMenu");
    }
}
