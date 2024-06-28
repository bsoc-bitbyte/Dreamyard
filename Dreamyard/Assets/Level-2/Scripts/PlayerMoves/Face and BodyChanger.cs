using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceandBodyChanger : MonoBehaviour
{   
    public SpriteRenderer FaceRenderer;

    public Special_moves special_Moves;

    public Sprite Happy;
    public Sprite LevelFinish;
    public Sprite Normal;
    public Sprite Angry;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (special_Moves.SpecialCharged){
            FaceRenderer.sprite = Angry;
        }

        else{
            FaceRenderer.sprite = Normal;
        }
    }
}
