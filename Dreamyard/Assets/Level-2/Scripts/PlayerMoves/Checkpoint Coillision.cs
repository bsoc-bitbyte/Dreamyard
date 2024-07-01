using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckpointCollision : MonoBehaviour
{   Animator animator;  
    public Death death;
    public FruitCollision fruitCollision;


  private void OnTriggerEnter2D(Collider2D collider){
    if (collider.gameObject.CompareTag("Checkpoint")){
      animator = collider.gameObject.GetComponent<Animator>();
      animator.SetTrigger("Checkpoint Reached");

      death.InitialPosition = collider.gameObject.GetComponent<Transform>().position;
      fruitCollision.LastFruitCollected = Vector3.zero;

    }
  }
}
