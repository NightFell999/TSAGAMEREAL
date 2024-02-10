using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTeleport : MonoBehaviour
{
    public GameObject player;
    public Collider2D sensor;
    public bool isInRange;
    public GameObject teleportSpot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = teleportSpot.transform.position;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
    }
}
