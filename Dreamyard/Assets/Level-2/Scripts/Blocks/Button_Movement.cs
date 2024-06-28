using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button_Movement : MonoBehaviour
{   
    [SerializeField] Transform ButtonGround;

    public MovingThePlatform movingThePlatform;


    bool hasCollided;
    public bool isPressed;
    public float velocity;


    
    void Start(){
        isPressed = false;
        hasCollided = false;
    }
    
    void Update(){

        if (hasCollided){
            if (Vector3.Distance(transform.position, ButtonGround.position) > 0.05f){
                transform.position = Vector3.Lerp(transform.position, ButtonGround.position, velocity);
            }
            else{
                isPressed = true;
                movingThePlatform.I_LIKE_IT = true;

            }
        }

    }
    
    private void OnCollisionEnter2D(Collision2D collider){
        if (collider.gameObject.CompareTag("Player")){
            
            hasCollided = true;
        }
    }

}
