using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    Transform destroy;
    public float velocity;

    void Start(){
        destroy = transform.parent.transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = Vector2.MoveTowards(transform.position, destroy.position, velocity*Time.deltaTime);

         if (Vector2.Distance(transform.position, destroy.position) < 0.1f){
            Destroy(gameObject);
         }
    }

    
}
