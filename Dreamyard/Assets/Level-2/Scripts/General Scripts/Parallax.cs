using System;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material material;
    float distance;

    [Range(0f, 0.5f)]
    public float speed;

    void Start(){
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Time.deltaTime*speed;
        material.SetTextureOffset("_MainTex", Vector2.right*distance);
        
    }
}
