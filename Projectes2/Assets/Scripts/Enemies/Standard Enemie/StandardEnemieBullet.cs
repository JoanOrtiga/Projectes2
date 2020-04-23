using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemieBullet : MonoBehaviour
{
    public float moveSpeed = 7f;
    public int DMG = 3;

    Rigidbody2D rb;
    private GameObject target;
    public GameObject shootingPoint;

    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {


        
        target = GameObject.FindGameObjectWithTag("Player");
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        Shoot();

    }

    void Shoot()
    {
        moveDirection = (target.transform.position - shootingPoint.transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().currentHP -= DMG;
        }
    }
}
