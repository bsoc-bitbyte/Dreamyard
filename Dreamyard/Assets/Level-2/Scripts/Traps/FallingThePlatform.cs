using UnityEngine;

public class FallingThePlatform : MonoBehaviour
{
    public float Timer;
    bool hasCollided;
    private float StartTime;
    public Animator animator;

    float FallSpeed = 200;

    [SerializeField] private Rigidbody2D Platform;
    
    Special_moves Special_Moves;
    shape_changer Shape_Changer;

    

    void Start(){
        StartTime = 0;
        Platform.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {  
        if ((StartTime + Timer) < Time.time && hasCollided && Special_Moves.SpecialCharged && Shape_Changer.isSquare){
            

            Platform.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            Platform.AddForce(Vector2.down*FallSpeed * Time.deltaTime);
            StartTime = 0;
            animator.SetBool("isFalling", true);
            
            Destroy(gameObject, 5.0f);
        }



    }

    private void OnCollisionEnter2D(Collision2D collider){
        if (collider.gameObject.CompareTag("Player")){
            hasCollided = true;
            StartTime = Time.time;
            Shape_Changer = collider.gameObject.GetComponent<shape_changer>();
            Special_Moves = collider.gameObject.GetComponent<Special_moves>();
        }  
    }

    private void OnCollisionExit2D(Collision2D collider){
        if (collider.gameObject.CompareTag("Player")){
            hasCollided = false;
            StartTime = 0;
        }
    }
}
