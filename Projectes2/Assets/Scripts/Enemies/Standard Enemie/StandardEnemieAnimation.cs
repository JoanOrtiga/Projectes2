using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemieAnimation : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void WalkingAnim(bool activation)
    {
        animator.SetBool("Moving", activation);
    }

    public void ShootingAnim(bool activation)
    {
        animator.SetBool("Moving", activation);
    }
}
