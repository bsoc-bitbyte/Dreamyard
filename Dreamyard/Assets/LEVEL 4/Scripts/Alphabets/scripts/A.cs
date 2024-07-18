using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    public GameObject ball;
    public bool A_pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        A_pressed = true;
        Debug.Log("Mouse Down A");
        Instantiate(ball, transform.position,Quaternion.identity);
        

    }
}
