using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class Special_moves : MonoBehaviour
{   
    public SpriteRenderer CharacterSprite;

    float Starttime = 0;
    float Holdtime;
    
    public bool SpecialCharged;

    void Start(){
        SpecialCharged = false;
        Holdtime = 0.5f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            Starttime = Time.time;
        }    

        if (Input.GetKey(KeyCode.LeftShift)){
            if (Starttime + Holdtime <= Time.time ){
                SpecialCharged = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)){
            SpecialCharged = false;
            Starttime = 0;
        }

    }
}
