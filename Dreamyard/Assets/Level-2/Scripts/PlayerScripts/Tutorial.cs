using TMPro;
using UnityEngine;

public class Turorial : MonoBehaviour
{   
    public TextMeshProUGUI TextBox;
    public GateOpen gateOpen;
    public BoxCollider2D JumpPadCollider;

    void Start()
    {   
        DisplayText(
        "Use A and D to move Left and Right\nPress I to change into a square \nPress J to change onto a Circle \nPress K to change into a triangle\nHold LShift to activate the special. You'll know when its activated.", null );

    }

    private void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.CompareTag("TutorialPoints")){
            if (collider.name == "1"){
                DisplayText
                ("Press SPACE to jump", collider.gameObject);
            }

            if (collider.name == "2"){
                DisplayText("Circles are balls faster and jump higher when activated.\nSquares are well that, squares they are heavy and strong.\nTriangles are sharp and they can break objects when pointing up.",collider.gameObject);
            }
            

            if (collider.name == "8"){
                DisplayText("Change to a Triangle and activate and break the block.\nA Circle will help you jump higher ", collider.gameObject);
            }

            if (collider.name == "9"){
                DisplayText("Follow the arrows, they lead to apples, collect all to win.\nRemember, when you die the last apple you collected will respawn.", collider.gameObject);
            }

            if (collider.name == "3"){
                DisplayText("A Moving Platform, Get on it but dont die \nand dont move on the platfrom, cause mom said so. But you can jump :]", collider.gameObject);
            }

            if (collider.name == "4"){
                DisplayText("Change to square and Jump \nsquares are heavy they break things and they are also strong", collider.gameObject);
            }

            if (collider.name == "5"){
                DisplayText("This is a jump pad, it'll launch you in the air. Just jump on it.", null);
                collider.enabled = false;
            }

            if (collider.name == "6"){

                if (JumpPadCollider.enabled){
                DisplayText("You missed the jump pad! Don't worry press LCtrl, you'll get tranported to the last checkpoint. Last apple will be revoked as a penalty.", null);
                }
                
                else{
                DisplayText("Nearing the end, Nice! Now get a square and push. Remember they are strong!", collider.gameObject);
                }
            }

            if (collider.name == "7"){
                if (gateOpen.OpenGate){
                DisplayText("Enter the gate, YOU WON", collider.gameObject);
                }

                else{
                DisplayText("Oops! You missed an apple somewhere, collect it to open the door", collider.gameObject);
                }
            }
        }
    }

    void DisplayText(string TextItem, GameObject curObject){
        TextBox.text = TextItem;
        Destroy(curObject);
    }
}