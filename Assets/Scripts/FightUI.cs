using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightUI : MonoBehaviour
{
    public GameObject fightUI;
    public GameObject enemyUI;
    public GameObject preTextUI;
    public Fight fightScript;
    public Player player;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    bool doOnce = false;
    public GameObject currentenemy;
    public int round = 0;

    public int UITracker = 0;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        pos1 = GameObject.Find("Position1");
        pos2 = GameObject.Find("Position2");
        pos3 = GameObject.Find("Position3");
        pos4 = GameObject.Find("Position4");
    }


    // Update is called once per frame
    void Update()
    {
        if(player.spellCountMAX == player.spellCountCURRENT)
        {
            UITracker = 2;
        }
        if(UITracker == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            UITracker = 1;
        }

        if(UITracker == 0 && player.isInFight == true)
        {
            preTextUI.SetActive(true);
        }
        else if(UITracker == 1)
        {
            Debug.Log("SHOULD DISPLAY ");
            preTextUI.SetActive(false);
            fightUI.SetActive(true);
        }
        else if(UITracker == 2)
        {
            fightUI.SetActive(false);
            enemyUI.SetActive(true);
        }
        else if(UITracker == 3)
        {
            enemyUI.SetActive(false);
            UITracker = 1;
        }
        
        
        /*
        if (player.isPlayersTurn == true && player.isInFight == true)
        {

            fightUI.SetActive(true);
            
        }
        else
        {
            Debug.Log("NOT ACTIVE");
            fightUI.SetActive(false);
        }
        */


        



    }
}
