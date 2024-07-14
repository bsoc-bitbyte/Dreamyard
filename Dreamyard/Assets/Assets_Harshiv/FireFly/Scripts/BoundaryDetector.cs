using UnityEngine;
using System.Collections.Generic;

public class BoundaryDetector : MonoBehaviour
{
    private List<FlyEye> flyEyes;

    void Start()
    {
        // Find all FlyEye objects in the scene by tag
        GameObject[] flyEyeObjects = GameObject.FindGameObjectsWithTag("Enemy");
        flyEyes = new List<FlyEye>();

        foreach (GameObject obj in flyEyeObjects)
        {
            FlyEye flyEye = obj.GetComponent<FlyEye>();
            if (flyEye != null)
            {
                flyEyes.Add(flyEye);
            }
        }

        if (flyEyes.Count == 0)
        {
            Debug.LogError("No FlyEye objects with tag 'Enemy' found in the scene.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            foreach (FlyEye flyEye in flyEyes)
            {
                flyEye.SetPlayerInBoundary(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            foreach (FlyEye flyEye in flyEyes)
            {
                flyEye.SetPlayerInBoundary(false);
            }
        }
    }
}
