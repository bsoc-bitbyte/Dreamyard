using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class MovingThePlatform : MonoBehaviour
{

    public Transform Position_A;
    public Transform Position_B;
    public float speed;
    
    public bool I_LIKE_IT;
    public Animator animator;


    Vector2 TargetPosition;

    void Start(){
        transform.position = Position_A.position;
    }

    void Update(){
        
        if (I_LIKE_IT) {
            animator.SetBool("isMoving", true);

            if (Vector2.Distance(transform.position, Position_A.position) < 0.1f){
                TargetPosition = Position_B.position;
            }

            
            if (Vector2.Distance(transform.position, Position_B.position) < 0.1f){
                TargetPosition = Position_A.position;
            }
        
            if (I_LIKE_IT){
            transform.position = Vector2.MoveTowards(transform.position, TargetPosition, speed*Time.deltaTime);  
            }
        
        }    

        else{
            animator.SetBool("isMoving", false);
        }


    } 

    private void OnCollisionEnter2D(Collision2D collider){
        if (collider.gameObject.CompareTag("Player")){
            collider.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collider){
        if (collider.gameObject.CompareTag("Player")){
            collider.transform.SetParent(null);
        }
    }



      
}
