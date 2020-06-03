using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    [HideInInspector]
    public float velX;

    public float velY=3.0f;

    Rigidbody2D rb2D;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = new Vector2(velX, velY);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Boss")||other.gameObject.CompareTag("Enemie"))
        {

        }
        else
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
