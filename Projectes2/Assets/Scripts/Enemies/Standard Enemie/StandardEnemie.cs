using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemie : MonoBehaviour
{

    public int health = 5;
    public float timeTilHit = 3f;
    public float chaseDistance = 10;
    public float chaseSpeed = 5f;

    public GameObject bullet;


    private float distance;
    private GameObject target;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        distance = (target.transform.position.x - transform.position.x);

        
        Chase();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            InvokeRepeating("Attack", 0.2f, timeTilHit);
        }

    }

    void Chase()
    {
        if (distance < chaseDistance && distance > this.gameObject.GetComponent<CircleCollider2D>().radius)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, chaseSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        print("SHoot");
        //shoot
    }


}
