using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    public Player playerScript;
    public Fight fightScript;
    public Canvas canvas;
    public GameObject HealthBarUI;
    public int counter;
    public bool doOnce = true;
    public Vector3 startPos;
    public GameObject[] HealthBarUIArray;
    public bool isAlreadyRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        fightScript = GameObject.Find("Player").GetComponent<Fight>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    float noNegative(float input)
    {
        if(input <= 0)
        {
            input = 0;
        }
        return input;

    }

    void spawnUI()
    {
        HealthBarUIArray = new GameObject[4];
        for (int i = 0; i < fightScript.finalenemylist.Length; i++)
        {


            GameObject ui = Instantiate(HealthBarUI, canvas.transform, false);
            ui.GetComponent<RectTransform>().anchoredPosition = startPos + (counter * new Vector3(200, 0, 0));
            counter += 1;
            
            HealthBarUIArray[i] = ui;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if(playerScript.isInFight == true && doOnce == true)
        {
            spawnUI();
            doOnce = false;
            
        }
        else if(playerScript.isInFight == true)
        {
            for(int i = 0; i < HealthBarUIArray.Length; i++)
            {
                if(HealthBarUIArray[i].GetComponentInChildren<Image>().fillAmount > ((float)(fightScript.finalenemylist[i].GetComponent<Enemy>().enemycurrentHealth) / (fightScript.finalenemylist[i].GetComponent<Enemy>().enemymaxHealth))){
                    HealthBarUIArray[i].GetComponentInChildren<Image>().fillAmount -= 0.005f;

                }
            }
            
        }
        else if(playerScript.isInFight == false)
        {
            doOnce = true;
            GameObject[] gameobjects = GameObject.FindGameObjectsWithTag("HealthBarUI");
            foreach(GameObject g in gameobjects)
            {
                Destroy(g);
            }
        }
    }
}
