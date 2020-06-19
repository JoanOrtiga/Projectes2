using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UIElements;

public class FlyingEnemie : EnemieManager
{
    public float timeAttacking = 1f;
    public float patrolSpeed;
    public float goingBackSpeed = 1f;
    public float attackSpeed;
    public Transform[] patrolSpots;
    

    private GameObject target;
    private bool patrolPoint = true;
    private Vector2 spot;


    private float startY;
    private float lastX;
    private float floatSpan = 1.0f;
    private float upDownSpeed = 2;
    private float actualTime;
    private bool scriptActivate = true;
    private bool isGoingBack = false;

    public int manaRecover = 50;

    [SerializeField]
    private bool isPatroling = true;

    Animator m_Animator;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        startY = transform.position.y;


        transform.localRotation = Quaternion.Euler(0, 180, 0);
        spot = patrolSpots[0].position;
        m_Animator = this.GetComponent<Animator>();

    }

    void Update()
    {
        if (isGoingBack)
        {
            goingBack();
        }
        death();


    }


    public void attack()
    {
        lastX = transform.position.x;
        transform.position = Vector2.MoveTowards(transform.position, target.GetComponent<Transform>().position, attackSpeed * Time.deltaTime);
        if (transform.position.x < lastX)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void patrol()
    {


        transform.position = new Vector2(transform.position.x, (float)(startY + Mathf.Sin(Time.time * upDownSpeed) * floatSpan / 2.0)); //moving up and down

        transform.position = Vector2.MoveTowards(transform.position, spot, patrolSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, spot) < 2f)
        {
            patrolPoint = !patrolPoint;

        }
        if (patrolPoint)
        {
            spot = patrolSpots[1].position;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (patrolPoint == false)
        {
            spot = patrolSpots[0].position;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }



    }

    void activateScript(bool activate)
    {
        if (activate)
        {
            this.GetComponent<FlyingAlienFOV>().enabled = true;
        }
        else
        {
            this.GetComponent<FlyingAlienFOV>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().currentHP -= DMG;
            isGoingBack = true;
            isPatroling = false;
            actualTime = 100;
        }
    }

    void goingBack()
    {
        lastX = transform.position.x;
        activateScript(false);
        transform.position = Vector2.MoveTowards(transform.position, spot, goingBackSpeed * Time.deltaTime);

        if (transform.position.x < lastX)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (Vector2.Distance(transform.position, spot) < 0.2f)
        {
            activateScript(true);
            isGoingBack = false;
        }
    }

    void death()
    {
        if (HP <= 0)
        {
            GameObject.FindGameObjectWithTag("BulletManager").GetComponent<StainManager>().manaCalculator(true, manaRecover);
            m_Animator.SetBool("Dead", true);

            Invoke("InvokeDestroy", 2.3f);
        }
    }

    private void InvokeDestroy()
    {
        m_Animator.SetBool("Dead", false);

        transform.parent.gameObject.SetActive(false);
    }

}
