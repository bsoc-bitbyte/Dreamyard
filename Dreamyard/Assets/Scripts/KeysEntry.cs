using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeysEntry : MonoBehaviour
{
    public Sprite[] keys;
    public KeyControl key;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("keyHole1") && key.keysCollected[0] == 1)
        {
            collision.GetComponent<SpriteRenderer>().sprite = keys[0];
            count++;
            key.keysCollected[0] = 0;
        }
        if (collision.CompareTag("keyHole2") && key.keysCollected[1] == 1)
        {
            collision.GetComponent<SpriteRenderer>().sprite = keys[1];
            count++;
            key.keysCollected[1] = 0;
        }
        if (collision.CompareTag("keyHole3") && key.keysCollected[2] == 1)
        {
            collision.GetComponent<SpriteRenderer>().sprite = keys[2];
            count++;
            key.keysCollected[2] = 0;
        }
        if (collision.CompareTag("keyHole4") && key.keysCollected[3] == 1)
        {
            collision.GetComponent<SpriteRenderer>().sprite = keys[3];
            count++;
            key.keysCollected[3] = 0;
        }
    }
}
