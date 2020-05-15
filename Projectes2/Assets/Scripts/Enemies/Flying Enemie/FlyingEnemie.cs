using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FlyingEnemie : MonoBehaviour
{
    public float timeAttacking = 1f;
    public float patrolSpeed1;
    public float patrolSpeed2;
    public float attackSpeed;
    public Transform[] patrolSpots;
    

    private GameObject target;
    private bool patrolPoint = true;
    private Vector2 spot;


    private float startY;
    private float floatSpan = 1.0f;
    private float upDownSpeed = 2;
    private float actualTime;
    private bool scriptActivate = true;
    

    public bool isPatroling = true;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        startY = transform.position.y;


        transform.localRotation = Quaternion.Euler(0, 180, 0);
        spot = patrolSpots[0].position;
       
    }

    void Update()
    {

        patrol();
       
    }


    public void attack()
    {
        
        if (!(actualTime > timeAttacking))
        {
            actualTime += Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.GetComponent<Transform>().position, attackSpeed * Time.deltaTime);
            print("ATTACKING");
        }
        else
        {
            //patrol();
            //isPatroling = true;
            //actualTime = 0;
        }
    }

    public void patrol()
    {
        if (scriptActivate)
        {
            if (isPatroling)
            {

                transform.position = new Vector2(transform.position.x, (float)(startY + Mathf.Sin(Time.time * upDownSpeed) * floatSpan / 2.0)); //moving up and down

                transform.position = Vector2.MoveTowards(transform.position, spot, patrolSpeed1 * Time.deltaTime);

                if (Vector2.Distance(transform.position, spot) < 0.2f)
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
            else
            {
                transform.position = new Vector2(transform.position.x, (float)(startY + Mathf.Sin(Time.time * upDownSpeed) * floatSpan / 2.0)); //moving up and down

                transform.position = Vector2.MoveTowards(transform.position, spot, patrolSpeed2 * Time.deltaTime);

                if (Vector2.Distance(transform.position, spot) < 0.2f)
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
        }
        
        
    }

    void activateScript()
    {
        this.GetComponent<FlyingAlienFOV>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("HIT");
            patrol();
            isPatroling = true;
            actualTime = 100;
        }
    }
}
