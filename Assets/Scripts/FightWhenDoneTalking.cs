using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightWhenDoneTalking : MonoBehaviour
{
    public bool doOnce = true;
    public bool reallyDoneTalking = false;
    public Fight fight;
    public GameObject enem1;
    public GameObject enem2;
    public GameObject enem3;
    public GameObject enem4;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(reallyDoneTalking == true && doOnce == true)
        {
            fight.StartFight(enem1, enem2, enem3, enem4);
        }
    }
}
