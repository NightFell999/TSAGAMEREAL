using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerQuest : MonoBehaviour
{
    public GameObject Dealer;
    public GameObject Flower;
    public GameObject Buyer;
    public GameObject Fighter;
    public FightWhenDoneTalking fwdt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Dealer.GetComponent<NPC>().completedAvailableText && Flower.GetComponent<NPC>().completedAvailableText)
        {
            Buyer.GetComponent<NPC>().currentStopPoint = 1;
        }

        if(Buyer.GetComponent<NPC>().currentStopPoint == 1 && Buyer.GetComponent<NPC>().completedAvailableText == true)
        {
            Fighter.GetComponent<NPC>().currentStopPoint = 1;
        }

        if (Fighter.GetComponent<NPC>().currentStopPoint == 1 && Fighter.GetComponent<NPC>().completedAvailableText == true)
        {
            fwdt.reallyDoneTalking = true;
        }

    }
}
