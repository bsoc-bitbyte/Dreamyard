using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingPlatform : MonoBehaviour
{
    public int speed;
    public int direction;
    Vector3  targetPos;

    public GameObject Ways;
    public Transform[] wayPoints;
    int pointIndex;
    int pointCount;

    public float waitDuration;


    private void Awake()
    {
        wayPoints = new Transform[Ways.transform.childCount];
        for(int i=0; i<Ways.gameObject.transform.childCount ; i++)
        {
            wayPoints[i] = Ways.transform.GetChild(i).gameObject.transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pointIndex = 1;
        pointCount = wayPoints.Length;
        direction = 1;  
        speed = 2;
        targetPos = wayPoints[1].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, targetPos) < 0.05f)
        {
            NextPoint();
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) collision.transform.parent = null;
    }

    void NextPoint()
    {
        transform.position = targetPos;

        if (pointIndex == pointCount - 1) direction = -1;
        if (pointIndex == 0) direction = 1;

        targetPos = wayPoints[pointIndex].transform.position;
        pointIndex += direction;
    }
}
