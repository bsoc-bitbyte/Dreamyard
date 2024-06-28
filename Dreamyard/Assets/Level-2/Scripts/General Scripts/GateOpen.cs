using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GateOpen : MonoBehaviour
{   
    public FruitCollision fruitCollision;
    public int FruitsToBeCollected;
    public Animator animator;

    public bool OpenGate;
    public FaceandBodyChanger faceandBodyChanger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FruitsToBeCollected == fruitCollision.CountTillNow){
            OpenGate = true;
            animator.SetTrigger("isOpen");
            faceandBodyChanger.FaceRenderer.sprite = faceandBodyChanger.LevelFinish;
        }
    }


}
