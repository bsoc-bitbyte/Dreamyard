using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{

    public Camera cam;
    public Transform followTarget;

    // starting position for the parallax game object
    Vector2 startingPosition;
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;
    float zdistanceFromTarget => transform .position.z - followTarget.transform.position.z;

    float clippingPlane => (cam.transform.position.z + (zdistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane)); 

    float parallaxFactor => Mathf.Abs(zdistanceFromTarget) / clippingPlane;

    //starting Z value of the parallax game object
    float startingZ;

    

    private void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;

    }

    private void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y,startingZ);
    }
}
