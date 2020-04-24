using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemie : MonoBehaviour
{
    public int health = 5;
    public int DMG = 2;
    public float patrolSpeed = 3f;
    public Transform[] patrolPoints = new Transform[2];
    public float attackDistance = 3;

    private Transform enemiePosition;
    private int pointDirection = 1;
    private GameObject player;
    private float distance;


    private bool isPatrol = true;
    private bool isChase = false;
    private bool isAttack = false;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {

        if (isPatrol)
        {
            patrol();
        }
        else if (distance < attackDistance)
        {
            Attack();
        }
        else if (isChase)
        {
            Chase();
        }

        if (health <=0)
        {
            Destroy(this.gameObject);
        }


        distance = (player.transform.position.x - transform.position.x);



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPatrol = false;
            isChase = true;
        }
        

    }

    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, patrolSpeed * Time.deltaTime);

    }


    void Attack()
    {
        print("ATTACK");
    }
    void patrol()
    {
        

        if (this.transform.position == patrolPoints[0].transform.position)
        {
            pointDirection = 2;
        }
        else if (this.transform.position == patrolPoints[1].transform.position)
        {
            pointDirection = 1;
        }

        if (pointDirection == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].transform.position, patrolSpeed * Time.deltaTime);
        }
        else if (pointDirection == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].transform.position, patrolSpeed * Time.deltaTime);

        }
    }
}
