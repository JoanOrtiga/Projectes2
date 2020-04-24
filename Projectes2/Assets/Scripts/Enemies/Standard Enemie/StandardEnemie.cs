using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemie : MonoBehaviour
{
   

    public int health = 5;
    public GameObject projectile;
    public float speed;
    public float timeToShoot = 3f;
    public GameObject shootingPoint;

    public float chaseDistance = 10f;

    private GameObject target;
    private float attackDistance;



    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        attackDistance = (this.gameObject.GetComponent<CircleCollider2D>().radius * 2) - 0.5f;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < attackDistance)
        {
            
        }
        else if (Vector2.Distance(transform.position, target.transform.position) < chaseDistance)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }


        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InvokeRepeating("Shoot", 0.2f, timeToShoot);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            CancelInvoke();

        }
       
    }

    void Shoot()
    {
        Instantiate(projectile, shootingPoint.transform.position, Quaternion.identity);
    }
}
