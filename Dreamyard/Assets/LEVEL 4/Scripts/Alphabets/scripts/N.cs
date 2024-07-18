using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N : MonoBehaviour
{
    public GameObject ball;
    public bool N_pressed = false;
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
        N_pressed = true;
        Debug.Log("Mouse Down N");
        Instantiate(ball, transform.position, Quaternion.identity);


    }
    public void SetPressedfalse()
    {
        N_pressed = false;
    }
}
