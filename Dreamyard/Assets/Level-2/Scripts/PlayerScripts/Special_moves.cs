using UnityEngine;

public class Special_moves : MonoBehaviour
{   
    public SpriteRenderer CharacterSprite;
    PlayerMovement playerMovement;

    float Starttime = 0;
    float Holdtime;
    
    public bool SpecialCharged;


    void Start(){
        SpecialCharged = false;
        Holdtime = 0.5f;
        playerMovement = transform.GetComponent<PlayerMovement>();
        Circle_Special(transform.GetComponent<shape_changer>().isCircle);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            Starttime = Time.time;
        }    

        if (Input.GetKey(KeyCode.LeftShift)){
            if (Starttime + Holdtime <= Time.time ){
                SpecialCharged = true;
                Circle_Special(transform.GetComponent<shape_changer>().isCircle);
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)){
            SpecialCharged = false;
            Starttime = 0;
            Circle_Special(transform.GetComponent<shape_changer>().isCircle);
        }

    }

        void Circle_Special(bool isCircle){

        if (SpecialCharged && isCircle){
            playerMovement.jump_strength = 1000f;
            playerMovement.velocity = 10;
        }

        else {
            playerMovement.jump_strength = 800f;
            playerMovement.velocity = 8;
        }
    }
}
