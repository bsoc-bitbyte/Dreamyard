using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G : MonoBehaviour
{
    public GameObject ball;
    public bool G_pressed = false;
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
        G_pressed = true;
        Debug.Log("Mouse Down G");
        Instantiate(ball, transform.position, Quaternion.identity);


    }
    public void SetPressedfalse()
    {
        G_pressed = false;
    }
}
