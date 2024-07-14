using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalmove = 0f;
    public float speed = 40f;
    public Animator animator;
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       horizontalmove = Input.GetAxisRaw("Horizontal")*speed;
        
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.fixedDeltaTime, false, false);
        animator.SetFloat("speed",Mathf.Abs( horizontalmove * Time.fixedDeltaTime));
    }
}
