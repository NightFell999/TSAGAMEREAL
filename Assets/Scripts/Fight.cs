using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public Player p;
    public World w;
    public int fightRound = 0;
    public UIScript uiScript;



    GameObject char1;
    GameObject char1FightPos;
    GameObject e1FightPos;
    GameObject e2FightPos;
    GameObject e3FightPos;
    GameObject e4FightPos;
    Vector3 savePos2;

    Enemy enemyScript1;
    Enemy enemyScript2;
    Enemy enemyScript3;
    Enemy enemyScript4;

    public GameObject[] firstenemylist = new GameObject[4];
    public GameObject[] finalenemylist;
    public Spell currentSpell;

    bool DoOnce = true;



    void Start()
    {
        

        Debug.Log("Started");
        p = gameObject.GetComponent<Player>();
        w = GameObject.Find("World1").GetComponent<World>();


        //For Start Fight
        char1 = GameObject.Find("Player");
        char1FightPos = GameObject.Find("Arena1");
        e1FightPos = GameObject.Find("Enem1");
        e2FightPos = GameObject.Find("Enem2");
        e3FightPos = GameObject.Find("Enem3");
        e4FightPos = GameObject.Find("Enem4");

    }


    public void EndFight()
    {
        uiScript.turnOffUI = false;
        p.spellCountMAX = 20;
        p.spellCountCURRENT = 0;
        p.hits = 0;
        p.distanceWalked = 0;
        p.fightChance = 100;
        Debug.Log("Fight has ended");
        char1.transform.position = p.savePos;

        p.isInFight = false;

        foreach (GameObject i in GameObject.FindGameObjectsWithTag("enemy"))
        {
            Destroy(i);
        }
    }

    public void StartFight(GameObject e1, GameObject e2, GameObject e3, GameObject e4)
    {
        uiScript.turnOffUI = true;
        Debug.Log("Fight started");

        char1.transform.position = char1FightPos.transform.position;
        p.isInFight = true;
        p.isPlayersTurn = true;




        GameObject enem1 = Instantiate(e1);
        enem1.tag = "enemy";
        enemyScript1 = enem1.GetComponent<Enemy>();
        firstenemylist[0] = enem1;
        enem1.transform.position = e1FightPos.transform.position;

        GameObject enem2 = Instantiate(e2);
        enem2.tag = "enemy";
        enemyScript2 = enem1.GetComponent<Enemy>();
        
        enem2.transform.position = e2FightPos.transform.position;
        firstenemylist[1] = enem2;
        GameObject enem3 = Instantiate(e3);
        enem3.tag = "enemy";
        enemyScript3 = enem1.GetComponent<Enemy>();
        
        enem3.transform.position = e3FightPos.transform.position;
        firstenemylist[2] = enem3;

        GameObject enem4 = Instantiate(e4);
        enem4.tag = "enemy";
        enemyScript4 = enem1.GetComponent<Enemy>();
        firstenemylist[3] = enem4;
        enem4.transform.position = e4FightPos.transform.position;

        int enemynum = 1;
        for (int i = 0; i < firstenemylist.Length; i++)
        {
            if(firstenemylist[i].GetComponent<Enemy>().enemyName == "Empty")
            {

                Destroy(firstenemylist[i]);
                firstenemylist[i] = null;
            }
            else
            {
                firstenemylist[i].name = "Enemy " + enemynum;
                enemynum += 1;
            }
        }

        finalenemylist = new GameObject[enemynum-1];

        int counter = 0;
        for(int i = 0; i < 4; i++)
        {
            if(firstenemylist[i] != null)
            {
                finalenemylist[counter] = firstenemylist[i];
                counter += 1;
            }
            else
            {
                Debug.Log(firstenemylist[i] + " is null");
            }
        }
    }



    public void Roll()
    {

    }
}
