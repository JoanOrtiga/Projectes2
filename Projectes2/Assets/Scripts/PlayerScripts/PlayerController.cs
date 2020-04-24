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

    [HideInInspector] public float inputX;

    public float slopeForceRayLenght;
    public float slopeForce;

    private Collider2D lastStair;
    private bool colliding;
    private bool sPressed;

    private bool onLadder = false;

    private void Start()
    {
        thisSprite = this.GetComponent<SpriteRenderer>();

        currentHP = maxHP;
    }

    private void FixedUpdate()
    {
        Movment();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRedius, whatIsGround);

        if (isGrounded && !colliding && !sPressed)
        {
            if(lastStair!= null)
            {
                Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), lastStair, false);
            }
               
        }

        OnSlope();
        HandStairs();
    }

    private void Update()
    {
        Jump();

    }

    private void HandStairs()
    {
        if (Input.GetKey(KeyCode.W) && onLadder)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().position += new Vector2(0, 10) * Time.deltaTime;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    private void OnSlope()
    {
        float currentVerticalSpeed = GetComponent<Rigidbody2D>().velocity.y;

        print(colliding);
        if(isGrounded && currentVerticalSpeed > 0 && colliding)
        {
            speed = 30;
            GetComponent<Rigidbody2D>().velocity += new Vector2(0, -currentVerticalSpeed);
        }
        else
        {
            speed = 10;
        }

    }


    void Movment()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * speed, this.GetComponent<Rigidbody2D>().velocity.y);


        inputX = Input.GetAxis("Horizontal");

        if (inputX < -0.1)
        {
            thisSprite.flipX = true;
        }
        else if (inputX > 0.1)
        {
            thisSprite.flipX = false;
        }
    }

    public void Jump()
    {

        if (jumpPlayer == true && Input.GetButton("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("stairs"))
        {
            colliding = true;

            if (Input.GetKey(KeyCode.S))
            {
                sPressed = true;
                
                Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<Collider2D>(),true);
                lastStair = collision.gameObject.GetComponent<Collider2D>();

                
                StartCoroutine(downAgain());
            }

            StartCoroutine(collideAgain());
        }
    }

    IEnumerator collideAgain()
    {
        yield return new WaitForSeconds(0.7f);
        colliding = false;
    }

    IEnumerator downAgain()
    {
        yield return new WaitForSeconds(0.7f);
        sPressed = false;
        colliding = false;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            onLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            onLadder = false;
        }
    }
}
