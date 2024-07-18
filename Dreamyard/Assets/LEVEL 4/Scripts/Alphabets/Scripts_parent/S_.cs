using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S_ : MonoBehaviour
{
    
    public GameObject text;
    private TextMeshPro textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = text.GetComponent<TextMeshPro>();
        
        textMeshPro.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            textMeshPro.text = "S";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            textMeshPro.text = "";
        }
    }
}
