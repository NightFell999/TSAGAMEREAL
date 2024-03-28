using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnimation : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((gameObject.GetComponent<Rigidbody2D>().velocity.x != 0 || gameObject.GetComponent<Rigidbody2D>().velocity.y != 0) && gameObject.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            Debug.Log("UP");
            animator.SetTrigger("Is Moving Up");
        }
        else if ((gameObject.GetComponent<Rigidbody2D>().velocity.x != 0 || gameObject.GetComponent<Rigidbody2D>().velocity.y != 0))
        {
            Debug.Log("NOT UP");
            animator.SetTrigger("Is Moving");
        }




    }
}
