using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    Player player;
    Health health;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        health = GameObject.Find("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponentInChildren<Image>().fillAmount = (float)(health.playercurrentHealth / health.PlayermaxHealth);

        if(player.isInFight == false)
        {
            Image[] images = gameObject.GetComponentsInChildren<Image>();
            foreach(Image image in images)
            {
                image.enabled = false;
            }
        }
        else
        {
            Image[] images = gameObject.GetComponentsInChildren<Image>();
            foreach (Image image in images)
            {
                image.enabled = true;
            }
        }
    }
}
