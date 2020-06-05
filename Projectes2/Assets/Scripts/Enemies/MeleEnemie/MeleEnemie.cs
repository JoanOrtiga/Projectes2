﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemie : EnemieManager
{
    
    
    public float patrolSpeed = 3f;
    public float ChaseSpeed = 8f;
    public Transform[] patrolPoints;
    public float attackDistance = 3;
    public float chaseDistance = 6;

    private Transform enemiePosition;
    private int pointDirection = 1;
    private GameObject player;
    private float distance;
    private Vector2 spot;
    private bool patrolPoint;
    private bool isPatroling = true;
    private Animator animator;

    Vector3 lastPos;
    Vector3 currentPos;
    private bool checkDirectionBool = true;


    void Start()
    {
        lastPos = this.transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        spot = patrolPoints[0].position;
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = (player.transform.position.x - transform.position.x);
        distance = Mathf.Abs(distance);



        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }


        checkDirection();
        patrol();



    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Chase();
            Attack();

        }

        if (player.transform.position.x < this.transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPatroling = true;
        checkDirectionBool = true;
    }

    void Chase()
    {
        isPatroling = false;
        checkDirectionBool = false;
        //  print((distance < chaseDistance && distance > attackDistance) + " Chase " + chaseDistance + " attack " + attackDistance + "distace" + distance);
        if (distance < chaseDistance && distance > attackDistance)
        {
            print("CHASE");
            animator.SetBool("Chasing", true);
            animator.SetBool("Attacking", false);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, transform.position.z), ChaseSpeed * Time.deltaTime);
        }


    }


    void Attack()
    {
        isPatroling = false;
        checkDirectionBool = false;
        if (distance < attackDistance)
        {
            animator.SetBool("Attacking", true);
            print("ATTACK");
        }

    }

    void patrol()
    {
        if (isPatroling)
        {
            animator.SetBool("Chasing", false);
            animator.SetBool("Attacking", false);
            transform.position = Vector2.MoveTowards(transform.position, spot, patrolSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, spot) < 0.2f)
            {
                patrolPoint = !patrolPoint;

            }

            if (patrolPoint)
            {
                spot = patrolPoints[1].position;
                

            }
            else if (patrolPoint == false)
            {
                spot = patrolPoints[0].position;
               

            }
        }
    }

    void checkDirection()
    {
        if (checkDirectionBool)
        {
            currentPos = this.transform.position;
            //print("Last Pos:" + lastPos.x + "Current Pos" + currentPos.x);
            if (currentPos.x < lastPos.x)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            lastPos = currentPos;
        }
        
    }




}
