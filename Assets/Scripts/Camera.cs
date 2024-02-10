using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject camera;
    GameObject player;
    GameObject arena;
    Player playerscript;


    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        arena = GameObject.Find("Arena");
        playerscript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerscript.isInFight == true)
        {
            camera.transform.position = arena.transform.position - new Vector3(0, 0, 10);
        }
        else
        {
            camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }



    }
}
