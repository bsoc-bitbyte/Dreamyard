using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeroicDialogue : MonoBehaviour
{
    public GameObject window;
    public List<string> dialogues;
    public TMP_Text dialogueText;
    public float writingSpeed;

    private int index;
    private int charIndex; // Character Index

    private bool started;


    public bool IsDialogueFinished { get; private set; } // Public property to check if the dialogue is finished

    private void Awake()
    {
        ToggleWindow(false);
    }

    private void Start()
    {
        StartDialogue();
    }

    private void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }

    public void StartDialogue()
    {
        if (started)
        {
            return;
        }

        started = true;
        ToggleWindow(true);
        index = 0;
        GetDialogue(index);

    }

    public void GetDialogue(int i)
    {
        index = i;
        charIndex = 0;
        dialogueText.text = string.Empty;
        StartCoroutine(Writing());
    }

    public void EndDialogue()
    {
        started = false;

        IsDialogueFinished = true; // Set the dialogue finished flag
        StopAllCoroutines();
        ToggleWindow(false);
    }

    IEnumerator Writing()
    {
        yield return new WaitForSeconds(writingSpeed);

        string currentDialogue = dialogues[index];
        dialogueText.text += currentDialogue[charIndex];
        charIndex++;

        if (charIndex < currentDialogue.Length)
        {
            yield return new WaitForSeconds(writingSpeed);
            StartCoroutine(Writing());
        }
        else
        {
            StartCoroutine(WaitAndEndDialogue());
        }
    }

    IEnumerator WaitAndEndDialogue()
    {
        yield return new WaitForSeconds(1); 
        EndDialogue(); // End the dialogue
    }
}
