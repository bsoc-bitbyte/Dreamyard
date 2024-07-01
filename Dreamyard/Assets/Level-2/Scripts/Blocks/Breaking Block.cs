using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakingBlocks : MonoBehaviour
{   
    Special_moves Special_Moves;
    shape_changer Shape_Changer;

    bool hasCollided;

    Transform PlayerPosition;

    [SerializeField] private new ParticleSystem particleSystem;
    [SerializeField] public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        hasCollided = false;
    }

    // Update is called once per frame
    void Update()

    { 
        if (hasCollided && Special_Moves.SpecialCharged && Shape_Changer.isTriangle){
            if(PlayerPosition.position.y < this.transform.position.y){
                particleSystem.Play();
                spriteRenderer.enabled = false;
                Destroy(gameObject, 0.7f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collider){
        if (collider.gameObject.CompareTag("Player")){
            hasCollided = true;
            Special_Moves = collider.gameObject.GetComponent<Special_moves>();
            Shape_Changer = collider.gameObject.GetComponent<shape_changer>();
            PlayerPosition = collider.gameObject.GetComponent<Transform>();
        }
    }

    private void OnCollisionExit2D(Collision2D collider){
        hasCollided = false; 
    }
}
