using UnityEngine;

public class LevelChange : MonoBehaviour
{   
    GateOpen gateOpen;
    
    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.CompareTag("Finish")){

            gateOpen = collider.gameObject.GetComponent<GateOpen>();
            if (gateOpen.OpenGate){
                Debug.Log("level Change");
            }
        }
    }
}
