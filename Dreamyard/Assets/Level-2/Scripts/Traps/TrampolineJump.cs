using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrampolineJump : MonoBehaviour
{   
    public float JumpPadStrangth;
    public Rigidbody2D Player;

    public Animator animator;

    private void OnCollisionEnter2D(Collision2D collider){
        if (collider.gameObject.CompareTag("Player")){
            
            Player.AddForce(Vector2.up * JumpPadStrangth);
            animator.SetTrigger("JumpPad Use");

        }
    }



    
}
