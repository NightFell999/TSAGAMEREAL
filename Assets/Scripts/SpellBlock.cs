using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBlock : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public int speed;
    public GameObject container;
    public Spell spell;
    public Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        rb = gameObject.GetComponent<Rigidbody2D>();

        speed = -1 * speed;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, speed);
    }

    public void KillbyArrow()
    {
        player.spellCountCURRENT += 1;
        player.hits += 1;

        Destroy(gameObject);

    }

    public void KillbyWall()
    {
        if(gameObject != null)
        {
            player.spellCountCURRENT += 1;
        }

        Destroy(gameObject);
    }

}
