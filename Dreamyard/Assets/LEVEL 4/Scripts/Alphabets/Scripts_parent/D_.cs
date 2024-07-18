using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class D_ : MonoBehaviour
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

            textMeshPro.text = "D";
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
