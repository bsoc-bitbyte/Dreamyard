using UnityEngine;

public class GateOpen : MonoBehaviour
{   
    public FruitCollision fruitCollision;
    public int FruitsToBeCollected;
    public Animator animator;

    public bool OpenGate;
    public FaceandBodyChanger faceandBodyChanger;

    // Update is called once per frame
    void Update()
    {
        if (FruitsToBeCollected == fruitCollision.CountTillNow){
            OpenGate = true;
            animator.SetTrigger("isOpen");
            faceandBodyChanger.enabled = false;
            faceandBodyChanger.FaceRenderer.sprite = faceandBodyChanger.LevelFinish;
        }
    }


}
