using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B : MonoBehaviour
{
    public GameObject ball;
    public bool B_pressed = false;
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
        B_pressed = true;
        Debug.Log("Mouse Down B");
        Instantiate(ball, transform.position, Quaternion.identity);
        audioManager.Playsfx(audioManager.Alphabet_click);

    }
    public void SetPressedfalse()
    {
        B_pressed = false;
    }
}
