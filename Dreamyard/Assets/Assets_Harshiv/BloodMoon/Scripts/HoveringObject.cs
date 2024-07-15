using UnityEngine;

public class HoveringObject : MonoBehaviour
{
    public float hoverHeight = 0.1f;    // Height of hovering
    public float hoverSpeed = 1.0f;     // Speed of hovering
    private Vector2 startPos;           // Starting position of the object

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the vertical offset using a sine wave
        float offset = Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;

        // Apply the offset to the object's Y position
        Vector2 newPosition = startPos + new Vector2(0, offset);
        transform.position = newPosition;
    }
}
