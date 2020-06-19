using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float groundCheckRadius;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float slopeCheckDistance;
    [SerializeField]
    private float maxSlopeAngle;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private PhysicsMaterial2D noFriction;
    [SerializeField]
    private PhysicsMaterial2D fullFriction;


    [HideInInspector] public float xInput;
    private float slopeDownAngle;
    private float slopeSideAngle;
    private float lastSlopeAngle;
    public float ladderSpeed = 300;

    [HideInInspector]
    public int facingDirection = 1;

    public bool isGrounded;
    private bool isOnSlope;
    private bool isJumping;
    private bool canWalkOnSlope;
    private bool canJump;
    [HideInInspector] public bool jumpOnPaint;
    [HideInInspector] public bool onLadder;

    private Vector2 newVelocity;
    private Vector2 newForce;
    private Vector2 capsuleColliderSize;

    private Vector2 slopeNormalPerp;

    private Rigidbody2D rb;
    private CapsuleCollider2D cc;

    private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
        animator = this.GetComponent<Animator>();

        capsuleColliderSize = cc.size;
    }

    private void Update()
    {
        CheckInput();

        if (Input.GetKeyDown(KeyCode.B))
        {
            GetComponent<PlayerHealth>().RecieveDmg(100000);
        }

    }

    private void FixedUpdate()
    {
        CheckGround();
        SlopeCheck();
        ApplyMovement();
        Ladder();
    }

    private void Ladder()
    {
        if (onLadder && Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * Time.deltaTime * ladderSpeed); ;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 7;
        }
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (xInput == 1 && facingDirection == 1)
        {
            Flip();
        }
        else if (xInput == -1 && facingDirection == -1)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && jumpOnPaint)
        {
            animator.SetBool("Jumping", true);
            Jump();
        }



    }
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (rb.velocity.y <= 0.0f)
        {
            isJumping = false;
            animator.SetBool("Jumping", false);
        }

        if (isGrounded && !isJumping /*&& slopeDownAngle <= maxSlopeAngle*/)
        {
            canJump = true;
        }
    }

    private void SlopeCheck()
    {
        //Vector2 checkPos = transform.position - (Vector3)(new Vector2(0.0f, capsuleColliderSize.y / 2));
        Vector2 checkPos = groundCheck.position;

        SlopeCheckHorizontal(checkPos);
        SlopeCheckVertical(checkPos);
    }

    private void SlopeCheckHorizontal(Vector2 checkPos)
    {
        RaycastHit2D slopeHitFront = Physics2D.Raycast(checkPos, new Vector2(1, 0), slopeCheckDistance, whatIsGround);
        RaycastHit2D slopeHitBack = Physics2D.Raycast(checkPos, new Vector2(-1, 0), slopeCheckDistance, whatIsGround);

        if (slopeHitFront && !isJumping)
        {
            if (slopeHitFront.collider.CompareTag("stairs"))
            {
                isOnSlope = true;
                slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);
            }
        }
        else if (slopeHitBack && !isJumping)
        {
            if (slopeHitBack.collider.CompareTag("stairs"))
            {
                isOnSlope = true;
                slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
            }

        }
        else
        {
            slopeSideAngle = 0.0f;
            isOnSlope = false;
        }
    }

    private void SlopeCheckVertical(Vector2 checkPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, slopeCheckDistance, whatIsGround);

        if (hit)
        {
            if (hit.collider.CompareTag("stairs"))
            {


                slopeNormalPerp = Vector2.Perpendicular(hit.normal).normalized;

                slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

                if (slopeDownAngle != lastSlopeAngle)
                {

                    isOnSlope = true;
                }

                lastSlopeAngle = slopeDownAngle;

                Debug.DrawRay(hit.point, slopeNormalPerp, Color.blue);
                Debug.DrawRay(hit.point, hit.normal, Color.green);
            }
        }

        if (slopeDownAngle > maxSlopeAngle || slopeSideAngle > maxSlopeAngle)
        {
            canWalkOnSlope = false;
        }
        else
        {
            if (hit)
                if (hit.collider.CompareTag("stairs"))
                    canWalkOnSlope = true;
        }

        if (isOnSlope && canWalkOnSlope && xInput == 0.0f)
        {
            if (hit)
                if (hit.collider.CompareTag("stairs"))
                    rb.sharedMaterial = fullFriction;

        }
        else
        {
            rb.sharedMaterial = noFriction;
        }
    }

    private void Jump()
    {
        if (canJump)
        {
            canJump = false;
            isJumping = true;
            newVelocity.Set(0.0f, 0.0f);
            rb.velocity = newVelocity;
            newForce.Set(0.0f, jumpForce);
            rb.AddForce(newForce, ForceMode2D.Impulse);
        }
    }

    private void ApplyMovement()
    {
        if (isGrounded && !isOnSlope && !isJumping) //if not on slope
        {

            newVelocity.Set(movementSpeed * xInput, -7.0f);
            rb.velocity = newVelocity;
        }
        else if (isGrounded && isOnSlope && canWalkOnSlope && !isJumping) //If on slope
        {
            newVelocity.Set(movementSpeed * slopeNormalPerp.x * -xInput, movementSpeed * slopeNormalPerp.y * -xInput);
            rb.velocity = newVelocity;
        }
        else if (!isGrounded) //If in air
        {
            newVelocity.Set(movementSpeed * xInput, rb.velocity.y);
            rb.velocity = newVelocity;
        }

    }

    private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheck.position, slopeCheckDistance);

        Vector3 pos = groundCheck.position;
        Gizmos.DrawLine(pos, pos + new Vector3(1 * slopeCheckDistance, 0));
        Gizmos.DrawLine(pos, pos + new Vector3(-1 * slopeCheckDistance, 0));

    }
}
