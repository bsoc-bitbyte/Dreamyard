using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R : MonoBehaviour
{
    public GameObject ball;
    public bool R_pressed = false;
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
        R_pressed = true;
        Debug.Log("Mouse Down R");
        Instantiate(ball, transform.position, Quaternion.identity);
        audioManager.Playsfx(audioManager.Alphabet_click);

    }
    public void SetPressedfalse()
    {
        R_pressed = false;
    }
}
