using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Death : MonoBehaviour
{   
    public Vector3 InitialPosition;
    public Transform Player;

    public FruitCollision fruitCollision;
    public GameObject Fruit;

    public SpriteRenderer PlayerRenderer;
    public SpriteRenderer FaceRenderer;
    public new ParticleSystem particleSystem;


    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.CompareTag("Spikes")){
            
            StartCoroutine("MoveAfter");

            if (fruitCollision.LastFruitCollected != Vector3.zero){


            Instantiate(Fruit, fruitCollision.LastFruitCollected, new Quaternion(0,0,0,0));
            fruitCollision.LastFruitCollected = Vector3.zero;
            fruitCollision.CountTillNow --;

            }
        }
    }

    IEnumerator MoveAfter(){
        //before
        PlayerRenderer.enabled = false;
        FaceRenderer.enabled = false;
        
        particleSystem.Play();


        yield return new WaitForSeconds(0.3f);

        //after
        Player.position = InitialPosition;
        PlayerRenderer.enabled = true;
        FaceRenderer.enabled = true;
    }
}
