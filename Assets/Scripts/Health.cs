using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int PlayermaxHealth;
    public int playerminHealth; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer()
    {
        
    }

    public void DamageSingleEnemy()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        Fight fight = GameObject.Find("Player").GetComponent<Fight>();

        int randomEnemy = Random.Range(0, fight.finalenemylist.Length);


        //Damage Calculation
        int perfectModifier;

        if(player.spellCountCURRENT == player.spellCountMAX)
        {
            perfectModifier = 2;
        }
        else
        {
            perfectModifier = 1;
        }
        int damage = (int)((fight.currentSpell.spellDMG + 1.25f * (player.spellCountCURRENT - (player.spellCountMAX / 2))) * perfectModifier);

        if(damage < 0)
        {
            damage = 0;
        }
        //

        bool hasPositiveHealth = false;

        while(hasPositiveHealth != true)
        {
            if(fight.finalenemylist[randomEnemy].GetComponent<Enemy>().enemycurrentHealth > 0) {

                fight.finalenemylist[randomEnemy].GetComponent<Enemy>().enemycurrentHealth -= damage;
                hasPositiveHealth = true;
            }
            else
            {
                randomEnemy = Random.Range(0, fight.finalenemylist.Length);
            }


        }

        Debug.Log("Did " + damage + " damage.");
    }

    public void DamageAllEnemy()
    {
        Fight fight = GameObject.Find("Player").GetComponent<Fight>();



    }

    
}
