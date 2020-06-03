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
    private bool onMyWay = true;
    public int ataquesBarridos;
    private bool canStart;
    private bool izq;
    private bool active;

    private int numeroAtaques = 0;

    private void OnEnable()
    {
        active = true;
        numeroAtaques = 0;
        canStart = false;
        inpath = false;

        if ((transform.position - p1.transform.position).magnitude <= (transform.position - p2.transform.position).magnitude)
        {
            izq = true;
        }
        else
            izq = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (onMyWay && izq == true)
        {
            transform.position = new Vector2(transform.position.x + -1 * moveSpeed * Time.deltaTime,transform.position.y);
        }
        else if (onMyWay && izq == false)
        {
            transform.position = new Vector2(transform.position.x + 1 * moveSpeed * Time.deltaTime, transform.position.y);
        }

        if (canStart)
        {
            movement();
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (active)
        {
            if (other.CompareTag("WindowLimit"))
            {
                onMyWay = false;
                inpath = false;
                PathSelector();
            }
        }
    }


    void PathSelector()
    {
        numeroAtaques++;
        if(numeroAtaques > ataquesBarridos)
        {
            changeMov(BossStates.AtakBarrido);
            return;
        }

        if (!inpath)
        {
            pathChoser = Random.Range(0, 2);
            inpath = true;
            
            if (pathChoser == 0 && izq == false)
            {
                transform.position = p4.transform.position;
                izq = true;

            }
            else if (pathChoser == 1 && izq == false)
            {
                transform.position = p2.transform.position;
                izq = true;

            }
            else if (pathChoser == 0 && izq == true)
            {
                transform.position = p3.transform.position;
                izq = false;

            }
            else if (pathChoser == 1 && izq == true)
            {
                transform.position = p1.transform.position;
                izq = false;

            }

            canStart = true;


        }

    }
    void movement()
    {
        if (izq == true && pathChoser == 0)
        {
            transform.position = new Vector2(transform.position.x + -1 * moveSpeed * Time.deltaTime, transform.position.y);

        }
        else if (izq == true && pathChoser == 1)
        {
            transform.position = new Vector2(transform.position.x + -1 * moveSpeed * Time.deltaTime, transform.position.y);

        }
        if (izq == false && pathChoser == 0)
        {
            transform.position = new Vector2(transform.position.x + 1 * moveSpeed * Time.deltaTime, transform.position.y);

        }
        if (izq == false && pathChoser == 1)
        {
            transform.position = new Vector2(transform.position.x + 1 * moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
    private void OnDisable()
    {
        active = false;
    }
}
