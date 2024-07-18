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
    bool jump = false;
    public Rigidbody2D rb;

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
        horizontalmove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("isRunning", Mathf.Abs(horizontalmove * Time.fixedDeltaTime));

        if (Input.GetButtonDown("Jump"))
        {
            
            animator.SetBool("isJumping", true);
            jump = true;

        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.fixedDeltaTime, false, jump);

        if (animator.GetBool("isJumping"))
        {
            
            jump = false;
        }
    }

    
}
