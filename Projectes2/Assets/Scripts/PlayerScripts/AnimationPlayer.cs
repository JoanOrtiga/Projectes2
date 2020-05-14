using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private GameObject player;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");


        animator = player.GetComponent<Animator>();
    }


    private void Update()
    {
        Walk();
        Jump();
    }

    void Walk()
    {
        if (GetComponent<PlayerMovement>().xInput != 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    void Jump()
    {
        if (!player.GetComponent<PlayerController>().isGrounded)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
