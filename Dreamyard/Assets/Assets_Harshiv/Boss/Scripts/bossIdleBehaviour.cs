using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossIdleBehaviour : StateMachineBehaviour
{
    public float timer;
    public float maxTime;
    public float minTime;
    private int rand;

    private Transform playerTransform;
    private Transform bossTransform;

    [SerializeField] private AudioClip BossSphereClip;
    [SerializeField] private float volumeSphere;

    [SerializeField] private AudioClip BossArrowClip;
    [SerializeField] private float volumeArrow;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        rand = Random.Range(0, 5);

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        bossTransform = animator.transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            if (rand == 0)
            {
                animator.SetTrigger("Run");
            }
            else if (rand == 1 || rand == 2)
            {
                SoundManager.instance.PlaySound(BossArrowClip, volumeArrow);
                animator.SetTrigger("Arrow");

            }
            else
            {
                SoundManager.instance.PlaySound(BossSphereClip, volumeSphere);
                animator.SetTrigger("Sphere");
            }
        }
        else
        {
            timer -= Time.deltaTime;

            if (playerTransform.position.x < bossTransform.position.x)
            {
                FlipBoss(true); // Face left
            }
            else
            {
                FlipBoss(false); // Face right
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    void FlipBoss(bool faceLeft)
    {
        Vector3 scale = bossTransform.localScale;
        scale.x = faceLeft ? 0.6f : -0.6f; // Flip X scale to -1 to face left, 1 to face right
        bossTransform.localScale = scale;
    }

}
