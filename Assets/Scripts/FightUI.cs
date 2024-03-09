using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightUI : MonoBehaviour
{
    public GameObject fightUI;
    public GameObject enemyUI;
    public GameObject preTextUI;
    public GameObject enemySummon;
    public Canvas fightUICanvas;
    public Spell spell;
    public Fight fightScript;
    public Player player;
    public Health health;
    public Enemy enemyScript;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    bool doOnce = true;
    bool doOnce2 = true;
    public GameObject currentenemy;
    public int round = 0;
    bool doDamageOnce = true;
    bool[] deathArray;
    bool allDead;
    public int randomEnemySpell;
    


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

        allDead = AllDead(fightScript.finalenemylist);

        if(allDead == true)
        {
            round = 0;
            UITracker = 0;
            fightScript.EndFight();
            fightUICanvas.enabled = false;
            
            enemyUI.SetActive(false);
        }


        if (round == fightScript.finalenemylist.Length)
        {
            round = 0;
        }

        currentenemy = fightScript.finalenemylist[round];
        enemyScript = currentenemy.GetComponent<Enemy>();
        


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
            player.spellCountCURRENT = 0;
            doOnce = true;
            doOnce2 = true;
            doDamageOnce = true;
            player.isPlayersTurn = true;
            preTextUI.SetActive(true);
        }
        else if(UITracker == 1)
        {
            Debug.Log("Choose A Spell");
            preTextUI.SetActive(false);

            if (doOnce2)
            {

                fightUICanvas.enabled = true;
                doOnce2 = false;
            }
            
        }
        else if(UITracker == 2)
        {
            Debug.Log("Do Damage");


            if(doDamageOnce == true)
            {
                

                if (fightScript.currentSpell.singleTarget == true)
                {
                    health.DamageSingleEnemy();
                }
                else if (fightScript.currentSpell.singleTarget == false)
                {
                    health.DamageAllEnemy();
                }

                doDamageOnce = false;
            }



            randomEnemySpell = Random.Range(0, enemyScript.spells.Length);

            enemyUI.SetActive(true);
        }
        else if(UITracker == 3)
        {
            if(currentenemy.GetComponent<Enemy>().isDead == true)
            {
                round += 1;
            }


            doDamageOnce = true;

            Debug.Log("Enemies Turn");
            Debug.Log(enemySummon.name);
            enemyUI.SetActive(false);
            
            if(doOnce == true)
            {
                currentenemy.GetComponent<Enemy>().spells[randomEnemySpell].GetComponent<Spell>().CastSpell(enemySummon);
                doOnce = false;
            }

        }
        else if(UITracker == 4)
        {
            doOnce = true;
            doOnce2 = true;
            if(round == fightScript.finalenemylist.Length - 1)
            {
                round = 0;
            }
            else
            {
                round += 1;
            }
            
            player.spellCountCURRENT = 0;
            UITracker = 1;
            player.isPlayersTurn = true;
        }
        
       

    }

    bool AllDead(GameObject[] arr)
    {
        for(int i = 0; i < arr.Length; i++)
        {
            if(arr[i].GetComponent<Enemy>().isDead != true)
            {
                return false;
            }
        }

        return true;

    }
    
}
