using UnityEngine;

public class WolfPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed = 2f;
    private int currentPointIndex;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = patrolPoints[0].position;
        currentPointIndex = 0;
        animator.SetTrigger("Walking");
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        if (Mathf.Abs(transform.position.x - patrolPoints[currentPointIndex].position.x) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
            animator.SetTrigger("Walking");
        }

        Vector2 targetPosition = new Vector2(patrolPoints[currentPointIndex].position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // Change direction based on movement
        if (targetPosition.x > transform.position.x)
        {
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        }
        else if (targetPosition.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1.3f, 1.3f, 1.3f);
        }
    }
}
