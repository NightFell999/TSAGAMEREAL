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
            animator.parameters[0].Equals(true);
            animator.parameters[1].Equals(false);
        }
        else if ((gameObject.GetComponent<Rigidbody2D>().velocity.x != 0 || gameObject.GetComponent<Rigidbody2D>().velocity.y != 0))
        {
            animator.parameters[0].Equals(false);
            animator.parameters[1].Equals(true);
        }




    }
}
