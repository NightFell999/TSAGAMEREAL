using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int enemymaxHealth;
    public int enemycurrentHealth;
    public bool isEmpty;
    public bool isDead;
    public GameObject[] spells;


    private void Update()
    {
        if(enemycurrentHealth <= 0)
        {
            isDead = true;
        }
    }



}
