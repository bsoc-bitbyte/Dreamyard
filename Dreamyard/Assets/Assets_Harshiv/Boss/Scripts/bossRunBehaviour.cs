using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossRunBehaviour : StateMachineBehaviour
{
    public float timer;
    public float maxTime;
    public float minTime;

    private Transform playerPos;
    public float speed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = Random.Range(minTime, maxTime);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger("Idle");
        }
        else
        {
            timer -= Time.deltaTime;
        }

        Vector2 target = new Vector2(playerPos.position.x, animator.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);

        if ((target.x > animator.transform.position.x && animator.transform.localScale.x > 0) ||
            (target.x < animator.transform.position.x && animator.transform.localScale.x < 0))
        {
            Vector3 bossScale = animator.transform.localScale;
            bossScale.x *= -1;
            animator.transform.localScale = bossScale;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
