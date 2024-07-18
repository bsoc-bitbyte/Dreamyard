using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinManager : MonoBehaviour
{

    public int coinCount;
    public bool isCollected;
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = " : " + coinCount.ToString();
        isCollected = false;
    }
}
