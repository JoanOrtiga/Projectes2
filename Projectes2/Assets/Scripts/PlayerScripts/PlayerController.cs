using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public int currentHP;
    public int maxHP = 10;
    [HideInInspector]
    public bool jumpPlayer;
    public float Speed = 10f;
    public float jumpForce = 10f;
    private SpriteRenderer thisSprite;
    

    private void Start()
    {
        thisSprite = this.GetComponent<SpriteRenderer>();

        currentHP = maxHP;
    }

    private void Update()
    {
        Movment();
       if (jumpPlayer == true && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

    }


    void Movment()
    {
        float DirctionX = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + DirctionX, transform.position.y);

        if (Input.GetAxis("Horizontal") < -0.1)
        {
            thisSprite.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0.1)
        {
            thisSprite.flipX = false;
        }
    }

    public void Jump()
    {
       
           gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
        
        
    }

}
