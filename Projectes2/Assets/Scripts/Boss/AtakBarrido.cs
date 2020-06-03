using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtakBarrido : BossController
{
    public float atackSpeed;
    public float moveSpeed;
    public GameObject p1, p2, p3, p4;
    public int pathChoser;
    private bool inpath = false;
    private bool onMyWay=true;
    public int ataquesBarridos;
    private bool canStart;
    private bool izq;
    void Start()
    {
        Random.Range(0, 1);
    }

    private void OnEnable()
    {
        if (this.GetComponent<SpriteRenderer>().flipX == true)
        {
            izq = true;
        }
        else
        {
            izq = false;
        }
        canStart = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (onMyWay&&izq==true)
        {
            transform.position = Vector2.MoveTowards(transform.position, p2.transform.position, moveSpeed * Time.deltaTime);
        }
        else if (onMyWay && izq == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, p1.transform.position, moveSpeed * Time.deltaTime);
        }
        
        if (canStart)
        {
            movement();
        }
      
    }


     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LimitePantalla"))
        {
            onMyWay = false;
            inpath = false;
            canStart = false;
            PathSelector();
        }
    }
    void PathSelector()
    {
        if (!inpath)
        {
            pathChoser = Random.Range(0, 1);
            inpath = true;
            canStart = true;
            if (pathChoser == 0 && izq == false)
            {
                transform.position = p4.transform.position;
                gameObject.GetComponent<SpriteRenderer>().flipX=true;
                izq = true;

            }
            else if (pathChoser == 1 && izq == false)
            {
                transform.position = p2.transform.position;
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                izq = true;

            }
            else if (pathChoser == 0 && izq == true)
            {
                transform.position = p3.transform.position;
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                izq = false;

            }
            else if (pathChoser == 1 && izq == true)
            {
                transform.position = p1.transform.position;
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                izq = false;

            }
        }

    }
void movement()
    {
        if (izq == true && pathChoser == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, p3.transform.position, moveSpeed * Time.deltaTime);

        }
        else if (izq == true && pathChoser == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, p2.transform.position, moveSpeed * Time.deltaTime);

        }
        if (izq == false && pathChoser == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, p4.transform.position, moveSpeed * Time.deltaTime);

        }
        if (izq == false && pathChoser == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, p1.transform.position, moveSpeed * Time.deltaTime);

        }
    }
}
