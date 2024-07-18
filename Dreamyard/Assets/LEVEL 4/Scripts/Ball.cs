using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public CircleCollider2D col;
    
    public bool Sling = false;
    public Vector3 pos { get { return transform.position; } }
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        col= GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sling")
        {
            Sling=true;
        }
        
    }
    // Update is called once per frame
    public void Push(Vector2 force)
    {
        if(Sling)
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    

    public void Activaterb()
    {
        //rb.isKinematic = false;
    }

    public void DeActivaterb()
    {   rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
       // rb.isKinematic = true;
    }
    
}
