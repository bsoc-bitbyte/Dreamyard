using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 posOffset;
    public float smooth;

    public float minX; // Minimum X boundary
    public float maxX; // Maximum X boundary
    public float minY; // Minimum Y boundary
    public float maxY; // Maximum Y boundary

    Vector3 velocity;

    private void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, target.position + posOffset, smooth * Time.deltaTime);

        Vector3 newPosition = Vector3.SmoothDamp(transform.position, target.position + posOffset, ref velocity, smooth);

        // Clamp the new position within the defined boundaries
        float clampedX = Mathf.Clamp(newPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(newPosition.y, minY, maxY);

        // Set the camera's position to the clamped values
        transform.position = new Vector3(clampedX, clampedY, newPosition.z);

    }
}
