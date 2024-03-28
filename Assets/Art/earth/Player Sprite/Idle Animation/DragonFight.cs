using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFight : MonoBehaviour
{
    public bool isInBox;
    public BoxCollider2D box;
    public Fight fight;
    public FlowerQuest flower;
    public GameObject dragon;
    public GameObject empty;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInBox = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInBox = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInBox == true && Input.GetKeyDown(KeyCode.E) && flower.hasKey == true)
        {
            fight.StartFight(dragon, empty, empty, empty);
            fight.finalenemylist[0] = dragon;
        }
    }
}
