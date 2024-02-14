using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public NPC npc;
    bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && inRange == true && npc.completedAvailableText == true)
        { 
            Debug.Log("WORKING");
            if (npc.currentStopPoint == 0)
            {
                npc.completedAvailableText = false;
                npc.TextProgression();
            }
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;

    }
}
