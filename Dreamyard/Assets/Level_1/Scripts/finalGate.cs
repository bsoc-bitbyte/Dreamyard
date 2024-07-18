using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalGate : MonoBehaviour
{
    public KeysEntry insertedKey;
    Vector2 destination = new Vector2(41.84f, 37f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(insertedKey.count == 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, 3*Time.deltaTime);
        }
    }
}
