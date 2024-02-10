using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightUI : MonoBehaviour
{
    public GameObject fightUI;
    public GameObject enemyUI;
    public GameObject preTextUI;
    public GameObject enemySummon;
    public Spell spell;
    public Fight fightScript;
    public Player player;
    public Enemy enemyScript;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    bool doOnce = true;
    public GameObject currentenemy;
    public int round = 0;

    public int UITracker = 0;


    // Start is called before the first frame update
    void Start()
    {
        enemySummon = GameObject.Find("Enemy Summon Position");
        player = GameObject.Find("Player").GetComponent<Player>();
        pos1 = GameObject.Find("Position1");
        pos2 = GameObject.Find("Position2");
        pos3 = GameObject.Find("Position3");
        pos4 = GameObject.Find("Position4");
    }


    // Update is called once per frame
    void Update()
    {
        currentenemy = fightScript.finalenemylist[round];
        enemyScript = currentenemy.GetComponent<Enemy>();
        if(round == fightScript.finalenemylist.Length)
        {
            round = 0;
        }


        if(player.spellCountMAX == player.spellCountCURRENT && UITracker == 1)
        {
            UITracker = 2;
        }
        if (player.spellCountMAX == player.spellCountCURRENT && UITracker == 3)
        {
            UITracker = 4;
        }
        if (UITracker == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            UITracker = 1;
        }

        if(UITracker ==2 && Input.GetKeyDown(KeyCode.Space))
        {
            UITracker = 3;
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
            Debug.Log("Enemies Turn");
            Debug.Log(enemySummon.name);
            enemyUI.SetActive(false);
            int randomEnemySpell = Random.Range(0, enemyScript.spells.Length);
            if(doOnce == true)
            {
                currentenemy.GetComponent<Enemy>().spells[randomEnemySpell].GetComponent<Spell>().CastSpell(enemySummon);
                doOnce = false;
            }

        }
        else if(UITracker == 4)
        {
            doOnce = true;
            round += 1;
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
