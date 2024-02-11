using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordspeed;
    public bool playerisclose;
    private bool isTyping = false;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerisclose)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if (!isTyping && dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }
    }



    public void zeroText()
    {
        dialogueText.text = " ";
        index = 0;
        dialoguePanel.SetActive(false);
    }



    IEnumerator Typing()
    {
        isTyping = true;
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordspeed);
        }
        isTyping = false;
    }

    public void NextLine()
    {



        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = " ";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }

        contButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerisclose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerisclose = false;
            zeroText();
        }
    }
}