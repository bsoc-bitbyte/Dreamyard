using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GirlMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D Girl;
    private Animator animator;
    private float HorizontalInput;
    private CapsuleCollider2D capsuleCollider;





    private void Awake()
    {
        // Gravb references from the game.
        Girl = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if (CanMove)
        {

            float HorizontalInput = Input.GetAxis("Horizontal");

            //movement along horizontal axis
            Girl.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Girl.velocity.y);

            //Flip the charecter ;
            if (HorizontalInput > 0.1f)
            {
                transform.localScale = new Vector3(4, 4, 1);
            }
            else if (HorizontalInput < -0.1f)
            {
                transform.localScale = new Vector3(-4, 4, 1);
            }

            // jumping code;
            if (Input.GetKey(KeyCode.Space) && isGrounded() && CanMove)
            {
                Jump();
            }

            //set animator parameters;
            animator.SetBool("Run", HorizontalInput != 0); // The "" contains the original animator name;
            animator.SetBool("Grounded", isGrounded());

        }
        else
        {
            return;
        }
       


        

    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool("canMove");
        }
    }

    private void Jump()
    {

        Girl.velocity = new Vector2(Girl.velocity.x, 7.5f );
        animator.SetTrigger("Jump");
    }

   

    private bool isGrounded()
    {
        //boxcast holds following (origin,size,roation angle , vector pos of box , location of box , layer)

        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null ;
    }

    public bool CanAttack()
    {

        return (HorizontalInput == 0 && isGrounded()) ;
    }
}

