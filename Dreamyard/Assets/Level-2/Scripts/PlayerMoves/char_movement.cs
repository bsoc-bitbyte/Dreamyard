using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class char_movement : MonoBehaviour
{   
    private float horizontal;
    public float velocity ;
    public float jump_strength;

    public bool IsGrounded;

    [SerializeField] private Rigidbody2D my_character;


    // Update is called once per frame
    void Update()

    {   
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded){

            my_character.AddForce(Vector2.up* jump_strength);

        }

        if (Input.GetKeyUp(KeyCode.Space) && !IsGrounded){
            my_character.velocity = my_character.velocity - new Vector2(0, 5);
        }
    
    }

    private void FixedUpdate(){
        my_character.velocity = new Vector2(horizontal*velocity, my_character.velocity.y);
    }




    private void OnCollisionEnter2D(Collision2D collider){

        if (collider.gameObject.CompareTag("BasicGround") 
        || collider.gameObject.CompareTag("MovingPlatform")
        || collider.gameObject.CompareTag("FallingPlatform")
        ){
            IsGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collider){
 
        if (collider.gameObject.CompareTag("BasicGround") 
        || collider.gameObject.CompareTag("MovingPlatform")){
            IsGrounded = false;
        }

    }


}

