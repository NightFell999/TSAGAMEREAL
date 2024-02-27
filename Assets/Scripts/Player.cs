using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //General
    Camera camera;
    public World world;

    //For Movement
    [Header("For Movement")]
    [SerializeField]
    Rigidbody2D playerrb;
    public int speed;
    float speedLimit;

    [SerializeField]
    [Header("Check Distance")]
    //For CheckDistance
    public float distanceWalked;
    Vector3 lastPos;
    Vector3 currentPos;

    [SerializeField]
    [Header("Fight")]
    //For Start Fight
    public bool isInFight;
    public bool isPlayersTurn;

    [SerializeField]
    public Vector3 savePos;
    public Fight fight;
    public bool doOnce = true;
    public int rand1;
    public int rand2;
    public int rand3;
    public int rand4;
    public float fightChance;
    public GameObject[] spells = new GameObject[4];

    //FOR SPELLS
    [Header("Spells")]
    [SerializeField]
    public int spellCountMAX = 20; //HAS TO BE HIGHERR THAN CURRENT WHEN NOT IN FIGHT
    public int spellCountCURRENT;
    public int hits;

    [Header("SpellBook")]
    public bool isInSpellBook;


    bool EnemyTurnDoOnce = true;

    void Start()
    {
        //For Movement
        playerrb = gameObject.GetComponent<Rigidbody2D>();
        speedLimit = speed;
        fight = gameObject.GetComponent<Fight>();

        //For Check Distance
        lastPos = transform.position;
        currentPos = transform.position;

        world = GameObject.Find("World1").GetComponent<World>();
    }

    IEnumerator NowEnemiesTurn()
    {
        Debug.Log("NOW ENEMIES TURN");
        yield return new WaitForSeconds(.5f);
        isPlayersTurn = false;
    }

    void DoDamage()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        
        if(isInFight == true && spellCountMAX <= spellCountCURRENT)
        {

            if(EnemyTurnDoOnce == true)
            {
                Debug.Log("enemyturn1");
                DoDamage();
                StartCoroutine("NowEnemiesTurn");
                EnemyTurnDoOnce = false;
            }


        }

    }

    private void FixedUpdate()
    {
        if (!isInFight)
        {
            Movement();
        }
        else
        {
            playerrb.velocity = new Vector2(0,0);
        }

    }







    private void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY);

        playerrb.velocity = moveDirection * speed;

        if (playerrb.velocity.magnitude > speedLimit)
        {
            playerrb.velocity = playerrb.velocity.normalized * speedLimit;
        }
    }
    
    private void CheckDistance()
    {
        if (isInFight == false)
        {
            currentPos = transform.position;
            distanceWalked += Vector3.Distance(currentPos, lastPos);
            lastPos = currentPos;
        }

        if (distanceWalked >= 5 && isInFight == false)
        {
            fightChance = Random.Range(0, 20f);
            //Debug.Log("the random number was " + fightChance);


            if (fightChance < world.encounterRate)
            {
                Debug.Log("FIGHTSHOULDHAPPEN");

                rand1 = Random.Range(0, world.RandomEnemies.Length);
                rand2 = Random.Range(0, world.RandomEnemies.Length);
                rand3 = Random.Range(0, world.RandomEnemies.Length);
                rand4 = Random.Range(0, world.RandomEnemies.Length);

                if (rand1 != 0 || rand2 != 0 || rand3 != 0 || rand4 != 0)
                {
                    savePos = gameObject.transform.position;
                    fight.StartFight(world.RandomEnemies[rand1], world.RandomEnemies[rand2], world.RandomEnemies[rand3], world.RandomEnemies[rand4]);
                }
            }
            else
            {
                distanceWalked = 0;
            }
        }
    }

}
