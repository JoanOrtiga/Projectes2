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
    public float speed = 10f;
    public float jumpForce = 10f;
    private SpriteRenderer thisSprite;



    //Jump Check
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRedius = 0.1f;
    public LayerMask whatIsGround;


    private void Start()
    {

        
        thisSprite = this.GetComponent<SpriteRenderer>();

        currentHP = maxHP;
    }

    private void FixedUpdate()
    {
        Movment();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRedius, whatIsGround);
    }

    private void Update()
    {

        Jump();

    }


    void Movment()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * speed, this.GetComponent<Rigidbody2D>().velocity.y);



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

        if (jumpPlayer == true && Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
        }

    }

}
