using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeThrow : MonoBehaviour
{
    public GameObject Spike;
    public Transform destroy;

    public float SpawnRate;
    float timer;
    BoxCollider2D boxCollider;

    GameObject Clone;

    // Update is called once per frame
    void Update()
    {
        if (timer < SpawnRate){
            timer += Time.deltaTime;
        }

        else{
            Clone = (GameObject)Instantiate(Spike, transform.position, transform.rotation);
            boxCollider = Clone.transform.GetComponent<BoxCollider2D>();
            boxCollider.isTrigger = true;
            Clone.transform.parent = transform.parent;
            timer = 0;
        }
    }
}
