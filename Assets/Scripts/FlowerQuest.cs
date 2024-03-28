using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerQuest : MonoBehaviour
{
    public bool hasKey = false;
    
    public GameObject Dealer;
    public GameObject Flower;
    public GameObject Buyer;
    public GameObject Fighter;
    public Fight fight;
    public FightWhenDoneTalking fwdt;
    bool doOnce = true;

    public GameObject empty;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator WaitPLS()
    {
        yield return new WaitForSeconds(1.5f);
        
        fight.StartFight(Fighter, empty, empty, empty);
        fight.finalenemylist[0] = Fighter;
        Fighter.GetComponent<NPC>().dialoguePanel.SetActive(false);
        hasKey = true;
        StopCoroutine("WaitPLS");
    }

    // Update is called once per frame
    void Update()
    {
        if(Dealer.GetComponent<NPC>().completedAvailableText && Flower.GetComponent<NPC>().completedAvailableText)
        {
            Debug.Log("COMPLETE STEP 1");
            Buyer.GetComponent<NPC>().currentStopPoint = 1;
        }

        if(Buyer.GetComponent<NPC>().currentStopPoint == 1 && Buyer.GetComponent<NPC>().completedAvailableText == true)
        {
            Debug.Log("Complete step 2");
            Fighter.GetComponent<NPC>().currentStopPoint = 1;
        }

        if (Fighter.GetComponent<NPC>().currentStopPoint == 1 && Fighter.GetComponent<NPC>().index == Fighter.GetComponent<NPC>().dialogue.Length - 1 && doOnce == true)
        {
            doOnce = false;
            Debug.Log("HELLO");
            StartCoroutine("WaitPLS");


        }

    }
}
