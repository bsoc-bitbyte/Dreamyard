using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class holding : MonoBehaviour
{
    [SerializeField]
    private Transform grabpoint;
    [SerializeField]
    private Transform raypoint;
    [SerializeField] 
    private float rayddistance=0.2f;
    private int layerIndex;
    private GameObject grabbedObject;
    private bool isHolding=false;
    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHolding)
        {
            RaycastHit2D hitinfo = Physics2D.Raycast(raypoint.position, transform.right, rayddistance);
            if (hitinfo.collider != null && hitinfo.collider.gameObject.layer == layerIndex)
            {
                if (Keyboard.current.spaceKey.wasPressedThisFrame && grabbedObject == null)
                {
                    grabbedObject = hitinfo.collider.gameObject;
                    grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    grabbedObject.transform.position = grabpoint.position;
                    grabbedObject.transform.SetParent(transform);
                    isHolding = true;

                }
            }
        }
        else if (Keyboard.current.spaceKey.wasPressedThisFrame && isHolding)
        {
            grabbedObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            grabbedObject.transform.SetParent(null);
            grabbedObject = null;
            isHolding = false;
        }
        
    }
}
