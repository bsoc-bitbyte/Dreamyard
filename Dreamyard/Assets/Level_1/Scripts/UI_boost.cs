using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class UI_boost : MonoBehaviour
{
    public Player_update_script playerUpdate;
    public Text boostText;
    private int boostValue;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        boostValue = (int)playerUpdate.boostTimer;
        boostText.text = " : " + boostValue.ToString();
    }
}
