using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public KeyControl key;
    GameObject gate1;
    GameObject gate2;

    // Start is called before the first frame update
    void Start()
    {
        gate1 = GameObject.FindGameObjectWithTag("restricted1");
        gate2 = GameObject.FindGameObjectWithTag("restricted2");
    }

    // Update is called once per frame
    void Update()
    {
        if (key.keysCollected[1] == 1) Destroy(gate1);
        if (key.keysCollected[2] == 1) Destroy(gate2);
    }
}
