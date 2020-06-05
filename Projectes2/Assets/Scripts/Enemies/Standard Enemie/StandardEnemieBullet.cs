using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StandardEnemieBullet : MonoBehaviour
{
    public float DMG = 4;
    public float speed = 3f;
    private Transform player;
  // private Vector2 target;
    Rigidbody2D rb;
    private GameObject target;
    Vector2 moveDirection;
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        //target = new Vector2(player.position.x, player.position.y);


        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(this.gameObject, 2);

    }

    // Update is called once per frame
    void Update()
    {
       //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            collision.GetComponent<PlayerHealth>().currentHP -= DMG;
            //player.GetComponent<PlayerController>().currentHP -= DMG;


            Destroy(this.gameObject);
        }

        

    }
}
