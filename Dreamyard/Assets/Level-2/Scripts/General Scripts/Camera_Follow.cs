
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] Transform character;
    public Vector3 offset;
    public float velocity;


    // Update is called once per frame
    void Update()
    {   
        Vector3 camera_position = character.position + offset;
        transform.position = Vector3.Lerp(transform.position, camera_position, velocity);
    }
}
