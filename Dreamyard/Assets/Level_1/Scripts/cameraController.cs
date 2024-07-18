using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    Transform target;
    Vector3 velocity = Vector3.zero;
    [Range(0, 1)]
    public float smoothTime;
    public Vector3 postionOffset;

    [Header("Axis Limit")]
    public Vector2 xLimit;
    public Vector2 yLimit;

    // Start is called before the first frame update
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = target.position + postionOffset;
        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        
    }
}
