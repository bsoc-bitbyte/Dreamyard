using UnityEngine;

public class shape_changer : MonoBehaviour
{   

    [SerializeField] private SpriteRenderer PlayerSprite;

    public Sprite SpriteCircle;
    public Sprite SpriteSquare;
    public Sprite SpriteTriangle;

    public BoxCollider2D box_collider;
    public CircleCollider2D circle_collider;
    public PolygonCollider2D triangle_collider;

    public bool isSquare;
    public bool isTriangle;
    public bool isCircle; 


    // Update is called once per frame

    void Start(){
        isSquare = false;
        isCircle = true;
        isTriangle = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)){
            PlayerSprite.sprite = SpriteSquare;
            Collider_Changer("box");

        }

        if (Input.GetKeyDown(KeyCode.J)){
            PlayerSprite.sprite = SpriteCircle;
            Collider_Changer("circle");
        }

        if (Input.GetKeyDown(KeyCode.K)){
            PlayerSprite.sprite = SpriteTriangle;
            Collider_Changer("triangle");
        }

    }

    void Collider_Changer(string collider){

        box_collider.enabled = false;
        circle_collider.enabled = false;
        triangle_collider.enabled = false;

        isSquare = false;
        isCircle = false;
        isTriangle = false;
        transform.localScale = new Vector3(0.8f, 0.8f, 1);
        transform.GetChild(1).localScale = new Vector3(0.8f, 0.8f, 1);


        if (collider == "box"){
            box_collider.enabled = true;
            isSquare  =true;
        }

        
        else if (collider == "triangle"){
            triangle_collider.enabled = true;
            transform.localScale = new Vector3(0.8f, 1.5f, 1);
            transform.GetChild(1).localScale = new Vector3(0.8f, 0.45f, 1);
            isTriangle = true;
        }

        
        else if (collider == "circle"){
            circle_collider.enabled = true;
            isCircle =true;
            
        }

    }
}
