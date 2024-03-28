using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnimation : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer sr;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movement.x > 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
