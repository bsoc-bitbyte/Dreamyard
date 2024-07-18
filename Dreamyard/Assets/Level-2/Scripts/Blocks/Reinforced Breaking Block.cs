using UnityEngine;

public class ReinforcedBreakingBlock : MonoBehaviour
{

    public Special_moves Special_Moves;
    public shape_changer Shape_Changer;

    [SerializeField] public SpriteRenderer BlockSprite;
    [SerializeField] private Sprite WoodBoxSprite;

    bool hasCollided;
    float BlockState;

    public Transform PlayerPosition;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        hasCollided = false;
        BlockState = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if (hasCollided && Special_Moves.SpecialCharged && Shape_Changer.isTriangle){
            if(PlayerPosition.position.y < this.transform.position.y){

                
                if (BlockState==1){
                    BlockState =2;
                    animator.SetTrigger("BoxDestroyed");
                    Destroy(gameObject, 0.28f);
                    hasCollided = false;
                }
                

                else if (BlockState == 0){
                    BlockState = 1;
                    animator.SetTrigger("BoxBreaking");
                    BlockSprite.sprite = WoodBoxSprite;
                    hasCollided = false;
                }

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collider){
        if (collider.gameObject.CompareTag("Player")){
            hasCollided = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collider){
        hasCollided = false; 
    }
}