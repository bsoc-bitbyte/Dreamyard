using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S : MonoBehaviour
{
    public GameObject ball;
    public bool S_pressed = false;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        S_pressed = true;
        audioManager.Playsfx(audioManager.Alphabet_click);
        Debug.Log("Mouse Down S");
        Instantiate(ball, transform.position, Quaternion.identity);


    }
    public void SetPressedfalse() {
        S_pressed = false;
    }
}
