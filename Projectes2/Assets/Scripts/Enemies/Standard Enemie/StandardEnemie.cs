using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemie : MonoBehaviour
{
    private GameObject target;
    private float attackDistance;

    public GameObject projectile;
    public float speed;
    public float timeToShoot = 3f;
    public GameObject shootingPoint;

    public float chaseDistance = 10f;

    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        attackDistance = (this.gameObject.GetComponent<CircleCollider2D>().radius * 2) - 0.5f;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < attackDistance)
        {
            print("Attak");
        }
        else if (Vector2.Distance(transform.position, target.transform.position) < chaseDistance)
        {
            print("Chase");
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
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
        CancelInvoke();
    }

    void Shoot()
    {
        Instantiate(projectile, shootingPoint.transform.position, Quaternion.identity);
    }
}
