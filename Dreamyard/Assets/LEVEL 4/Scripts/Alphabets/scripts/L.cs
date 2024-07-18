using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L : MonoBehaviour
{
    public GameObject ball;
    public bool L_pressed = false;
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
        L_pressed = true;
        audioManager.Playsfx(audioManager.Alphabet_click);
        Debug.Log("Mouse Down L");
        Instantiate(ball, transform.position, Quaternion.identity);


    }
    public void SetPressedfalse()
    {
        L_pressed = false;
    }
}