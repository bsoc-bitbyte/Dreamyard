using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlAttack : MonoBehaviour
{
    public float buttonDelay = 3.0f; // delay between button presses;
    float lastKeyTime = 0; // cache the last pressed time;
    private Animator animator;
    private GirlMovement movement;
    [SerializeField] private Transform firePoint; // initial pos from where to fire
    [SerializeField] private GameObject[] fireBalls; // all the duplicates here 

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<GirlMovement>();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && movement.CanAttack())
        {
            if(Time.time >= lastKeyTime)
            {
                lastKeyTime = Time.time + buttonDelay;
                Attack();
            }

            
        }

        if(Input.GetMouseButtonDown(0) && movement.CanAttack())
        {
            animator.SetTrigger("BasicAttack1");
        }

        if(Input.GetKeyDown(KeyCode.Q) && movement.CanAttack())
        {
            animator.SetTrigger("BasicAttack2");
        }
    }

  
    private void Attack()
    {
        animator.SetTrigger("Attack");

        //pool fireball
        fireBalls[FindFireball()].transform.position = firePoint.position;
        fireBalls[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
        
    }

    private int FindFireball()
    {
        for(int i = 0; i < fireBalls.Length; i++)
        {
            if (!fireBalls[i].activeInHierarchy)
                return i;

            
        }
        return 0;
    }

}
