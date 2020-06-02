using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemie : EnemieManager
{

    public float shootDistance;
    public float chaseDistance;

    public GameObject projectile;
    public float speed;
    public float timeToShoot = 3f;
    public GameObject shootingPoint;

    private GameObject target;
    private Animator animator;

    private float actualTime;
    private float distance;
    


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        Death();
        actualTime += Time.deltaTime;

        distance = (target.transform.position.x - transform.position.x);
        distance = Mathf.Abs(distance);
        if (distance > chaseDistance)
        {
            animator.SetBool("Moving", false);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Flip();
            checkDistance();
        }
       
    }
    

    void checkDistance()
    {
        
        
        //print((distance < chaseDistance && distance > shootDistance)+ " distance " + (distance) + " chase distance " + (chaseDistance) + " Shoot distance " + (shootDistance));

        if (distance < chaseDistance && distance > shootDistance)
        {
            print("Chase");
            
            Chase();
        }
        else if(distance <= shootDistance)
        {
            print("shoot");
            Shoot();
        }

        
        
    }


    public void Chase()
    {

        animator.SetBool("Moving", true);
        animator.SetBool("Shooting", false);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void Death()
    {
       

        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Shoot()
    {
        animator.SetBool("Moving", false);
        animator.SetBool("Shooting", true);

        if (actualTime >= timeToShoot)
        {
            actualTime = 0;
            Instantiate(projectile, shootingPoint.transform.position, Quaternion.identity);
        }
    }

    void Flip()
    {


        if (target.transform.position.x > this.transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (target.transform.position.x < this.transform.position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
        
}
