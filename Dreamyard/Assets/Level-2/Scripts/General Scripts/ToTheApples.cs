using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ToTheApples : MonoBehaviour
{   
    public Transform FruitBasket;

    public Transform[] Fruits;
    float velocity;
    public Camera_Follow camera_Follow;
    int index;

    public GateOpen gateOpen;

    // Start is called before the first frame update
    void Start()
    {
        Fruits = new Transform[FruitBasket.childCount];
        for (int i = 0; i < Fruits.Length; i++){

            Fruits[i] = FruitBasket.GetChild(i);
        }

        transform.position = new Vector3(-0.86f, 0.8f, -8.5f);
        index  = 0;
        velocity = 0.007f;

    }

    void Update(){
        transform.position = Vector3.Lerp(transform.position, Fruits[index].position + camera_Follow.offset, velocity);
        
        if (Vector3.Distance(transform.position, Fruits[index].position) < 8.55f){
            index ++;
        }

        if (index==gateOpen.FruitsToBeCollected){
            camera_Follow.enabled = true;
            this.enabled = false;
        }
        
    }

}
