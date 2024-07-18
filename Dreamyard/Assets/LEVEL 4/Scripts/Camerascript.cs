using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour

{
    // Start is called before the first frame update
    public Vector3 followspeed = Vector3.zero;
    public Vector3 offset = new Vector3 (0f,0f,-10f);
    public Transform target;
    
    public float smoothTime = 0.3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetposition=target.position+offset;
        
        transform.position = Vector3.SmoothDamp(transform.position,targetposition,ref followspeed,smoothTime);
    }
}
