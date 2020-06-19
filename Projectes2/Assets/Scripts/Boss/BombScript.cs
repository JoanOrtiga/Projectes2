using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private float velX=0;

    public float velY=10.0f;

    Rigidbody2D rb2D;

    public GameObject explosion;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(velX, -velY);
    }
   
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")||other.CompareTag("Finish"))
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerHealth>().currentHP -= damage;
            }
            Instantiate(explosion, transform.position, transform.rotation);

            FindObjectOfType<AudioManager>().Play("BossBomb");

            Destroy(gameObject);
        }
    }
}
