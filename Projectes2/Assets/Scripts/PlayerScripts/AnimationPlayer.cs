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
    }

    void Walk()
    {
        if (GetComponent<PlayerController>().inputX != 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
}
