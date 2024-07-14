using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMagic : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] magicBalls;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    [SerializeField] private AudioClip MagicProjectileClip;
    [SerializeField] private float volume;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(1) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        SoundManager.instance.PlaySound(MagicProjectileClip, volume);
        anim.SetTrigger("MagicAttack");
        cooldownTimer = 0;

       
    }

    private void Shoot()
    {
        magicBalls[FindMagicBall()].transform.position = firePoint.position;
        magicBalls[FindMagicBall()].GetComponent<Magic_Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindMagicBall()
    {
        for (int i = 0; i < magicBalls.Length; i++)
        {
            if (!magicBalls[i].activeInHierarchy)
            {
                return i;
            }
        }    
        return 0;
    }
}
