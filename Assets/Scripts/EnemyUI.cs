using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    public GameObject enemyUI;
    Player player;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(player.isPlayersTurn == false && player.isInFight == true)
        {
            enemyUI.SetActive(true);
            Debug.Log("ACTIVE");

        }
        else
        {
            enemyUI.SetActive(false);
        }
        */

    }
}
