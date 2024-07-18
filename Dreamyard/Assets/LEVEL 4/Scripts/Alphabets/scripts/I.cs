using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I : MonoBehaviour
{
    public GameObject ball;
    public bool I_pressed = false;
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
        audioManager.Playsfx(audioManager.Alphabet_click);
        I_pressed = true;
        Debug.Log("Mouse Down I");
        Instantiate(ball, transform.position, Quaternion.identity);


    }
    public void SetPressedfalse()
    {
        I_pressed = false;
    }
}
