using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField] public float attackDamage;
    

    private Health health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if (health != null)
        {
            Attack(health);  
        }
    }

    private void Attack(Health health)
    {
        health.TakeDamage(attackDamage);
    }

 
}

