using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DialougePanel;
    public Text DialougeText;
    public string[] dialouge;
    private int index;
    public float wordspeed;
    public bool PlayerIsClose;
    public GameObject contButton;
    public bool convo=false;

    // Update is called once per frame
    void Update()
    { if(!convo)
        {if (PlayerIsClose && Input.GetKeyDown(KeyCode.T)){
            convo = true;
            if (DialougePanel.activeInHierarchy)
            {
                zeroText();

            }
            else
            {
                DialougePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
            if (DialougeText.text == dialouge[index])
            {
                contButton.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerIsClose = false;
            zeroText();
        }
    }
    public void zeroText()
    {
        DialougeText.text = "";
        index= 0;
        DialougePanel.SetActive(false);
    }
    IEnumerator Typing()
    {
        foreach(char letter in dialouge[index].ToCharArray())
        {
            DialougeText.text += letter;
            yield return new WaitForSeconds(wordspeed);
        }
    }
    public void NextLine()
    {
        contButton.SetActive(false );
        if (index < dialouge.Length - 1)
        {
            index++;
            DialougeText.text= "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText() ;   
        }
    }
}
