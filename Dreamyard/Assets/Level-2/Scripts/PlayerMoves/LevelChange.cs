using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelChange : MonoBehaviour
{   
    GateOpen gateOpen;
    
    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.CompareTag("Gate")){

            gateOpen = collider.gameObject.GetComponent<GateOpen>();
            if (gateOpen.OpenGate){
                Debug.Log("level Change");
            }
        }
    }
}
