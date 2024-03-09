using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyUI : MonoBehaviour
{
    public GameObject enemyUI;
    public TextMeshProUGUI text;
    Player player;
    public int randomEnemySpell;
    public FightUI fightUIScript;
    public Enemy currentEnemy;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        randomEnemySpell = fightUIScript.randomEnemySpell;
        currentEnemy = fightUIScript.currentenemy.GetComponent<Enemy>();


        text.text = currentEnemy.enemyName + " attacked with " + currentEnemy.spells[randomEnemySpell].name + " Be ready to defend!";



    }
    // Update is called once per frame

}
