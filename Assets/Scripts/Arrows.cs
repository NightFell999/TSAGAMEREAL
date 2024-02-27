using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    Spell spell;
    public bool isWall;
    public KeyCode key;
    public bool isInside = false;

    public Collider2D[] list;
    public SpellBlock spellblk;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInside = true;

        //SET ALL BLOCKS TO SLIGHTLY DIFFERENT VALUES OR IT WONT WORK
        //COPY +2e-07

        spellblk = collision.GetComponent<SpellBlock>();



    }


    

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInside = false;
    }


    // Update is called once per frame
    void Update()
    {
        list = Physics2D.OverlapAreaAll(new Vector2(20, -7), new Vector2(40, -8.5f));

        Debug.Log(list.Length);

        if(list.Length != 0)
        {
            for (int i = 0; i < list.Length; i++)
            {
                spellblk = list[i].GetComponent<SpellBlock>();
                spellblk.KillbyWall();
            }
        }
       

        if (Input.GetKeyDown(key) && isInside)
        {
            spellblk.KillbyArrow();
        }

    }
}
