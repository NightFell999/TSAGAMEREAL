using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerQuest : MonoBehaviour
{
    GameObject Dealer;
    GameObject Flower;
    GameObject Buyer;


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
    }
}
