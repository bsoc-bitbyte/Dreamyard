using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Completion : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update.
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Game Completed");
            // add game completion logic here
            // destroy game object or trigger win condition
            Destroy(collision.gameObject);


            audioManager.Playsfx(audioManager.Level_completed);

            // to save the game progress
            // GameManager.instance.SaveGame();

            // to load the next level
            // SceneManager.LoadScene("NextLevel");

           
            SceneManager.LoadScene("Level5");}

        }
    }
