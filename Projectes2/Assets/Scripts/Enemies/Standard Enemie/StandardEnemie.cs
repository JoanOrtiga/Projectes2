using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemie : EnemieManager
{


    public GameObject projectile;
    public float speed;
    public float timeToShoot = 3f;
    public GameObject shootingPoint;

    private GameObject target;

    private float actualTime;
    


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");  
    }

    void Update()
    {
        Death();
        

        actualTime += Time.deltaTime;
    }


    public void Attack(bool activado)
    {
        Flip();
        if (activado)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }  
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
        Flip();
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
