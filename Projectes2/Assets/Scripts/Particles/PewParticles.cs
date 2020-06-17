using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewParticles : MonoBehaviour
{
    private int randomNumber = 0;
    private Animator animator;
    void Start()
    {
        randomNumber = Random.Range(1, 5);
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("number", randomNumber);

        Destroy(this.gameObject, 0.5f);
    }
}
