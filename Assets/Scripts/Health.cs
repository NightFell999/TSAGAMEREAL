using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float PlayermaxHealth;
    public float playercurrentHealth;
    public GameObject MovingText;
    public Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
        playercurrentHealth = PlayermaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar.fillAmount > playercurrentHealth/ PlayermaxHealth)
        {
            healthBar.fillAmount -= 0.005f;
        }
    }

    public void DamagePlayer()
    {

        Player player = GameObject.Find("Player").GetComponent<Player>();
        Fight fight = GameObject.Find("Player").GetComponent<Fight>();



        //Damage Calculation
        float perfectModifier;

        if (player.hits == player.spellCountMAX)
        {
            perfectModifier = (1 + (.25f * fight.currentSpell.spellDifficulty));
            DamageText("Perfect Defence", GameObject.Find("Player"));
        }
        else
        {
            perfectModifier = 1;
        }
        int damage = (int)((fight.currentSpell.spellDMG - (fight.currentSpell.spellDifficulty * (1 + ((player.hits * .15))) * perfectModifier)));

        if (damage < 0)
        {
            damage = 0;
        }

        Debug.Log("Player took " + damage + " damage");

        playercurrentHealth -= damage;
        DamageText(damage.ToString(), GameObject.Find("Player"));
        //
    }

    public void DamageSingleEnemy()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        Fight fight = GameObject.Find("Player").GetComponent<Fight>();

        int randomEnemy = Random.Range(0, fight.finalenemylist.Length);


        //Damage Calculation
        float perfectModifier;

        if(player.hits == player.spellCountMAX)
        {
            perfectModifier = (1 + (.25f * fight.currentSpell.spellDifficulty));
            DamageText("Perfect Attack", GameObject.Find("Player"));
        }
        else
        {
            perfectModifier = 1;
        }
        int damage = (int)((fight.currentSpell.spellDMG + (fight.currentSpell.spellDifficulty * (1 + (player.hits * .15))) * perfectModifier));

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
                DamageText(damage.ToString(), fight.finalenemylist[randomEnemy]);
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


    public void DamageText(string Damage, GameObject location)
    {
        int xValue = 2;

        if(Damage == "Perfect Defence")
        {
            xValue = -3;
        }


        GameObject damageText = Instantiate(MovingText, location.transform.position + new Vector3(xValue, 2f, 0), MovingText.transform.rotation);
        damageText.GetComponentInChildren<TextMeshPro>().text = Damage;

    }
    
}
