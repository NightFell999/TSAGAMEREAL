using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordspeed;
    public bool playerisclose = false;
    public bool isTyping = false;
    public int[] stopPoints;
    public int currentStopPoint;
    public int startPoint = 0;
    public bool completedAvailableText = false;

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



        if (!isTyping)
        {
            Debug.Log("Continue");
            contButton.SetActive(true);
        }
    }

    public void TextProgression()
    {
        Debug.Log("Is this working");
        startPoint = stopPoints[currentStopPoint];
        currentStopPoint += 1;
        
    }



    public void zeroText()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        index = startPoint;
        dialoguePanel.SetActive(false);
        
    }



    IEnumerator Typing()
    {
        Debug.Log(dialogue[index].ToCharArray());
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
        completedAvailableText = true;
        if (index == stopPoints[currentStopPoint] - 1)
        {
            zeroText();
        }
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = " ";
            StopAllCoroutines();
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