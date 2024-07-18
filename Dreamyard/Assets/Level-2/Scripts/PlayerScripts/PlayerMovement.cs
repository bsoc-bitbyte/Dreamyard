using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{   
    private float horizontal;
    public float velocity ;
    public float jump_strength;

    public bool IsGrounded;
    
    bool isOnPlatform;

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
        if (isOnPlatform){
        my_character.velocity = new Vector2(0, my_character.velocity.y);
        }

        else{
            my_character.velocity = new Vector2(horizontal*velocity, my_character.velocity.y);
        }
    }




    private void OnCollisionEnter2D(Collision2D collider){

        if (collider.gameObject.CompareTag("BasicGround") 
        || collider.gameObject.CompareTag("FallingPlatform")
        || collider.gameObject.CompareTag("HeavyBlock"))
        {
            IsGrounded = true;
        }

        if (collider.gameObject.CompareTag("MovingPlatform")){
            isOnPlatform = true;
            IsGrounded = true;
        }
    }

    

    private void OnCollisionExit2D(Collision2D collider){
 
        if (collider.gameObject.CompareTag("BasicGround") 
        || collider.gameObject.CompareTag("FallingPlatform")
        )
        {
            IsGrounded = false;
        }

        if ( collider.gameObject.CompareTag("MovingPlatform")){
            isOnPlatform = false;
            IsGrounded = true;
        }

    }


}

