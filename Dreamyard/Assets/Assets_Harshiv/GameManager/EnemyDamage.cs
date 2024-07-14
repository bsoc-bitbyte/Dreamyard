using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    private float damageCooldown = 1.0f;  
    private float lastDamageTime = -Mathf.Infinity;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Time.time > lastDamageTime + damageCooldown)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            lastDamageTime = Time.time;

        }
           
    }
}