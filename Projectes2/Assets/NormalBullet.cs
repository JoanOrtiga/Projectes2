using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    public int BulletSpeed;
    private Rigidbody2D rb2D;
    [HideInInspector] public Vector2 direction;
    public int Damage;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * BulletSpeed * Time.deltaTime);

    }
    private void FixedUpdate()
    {
        rb2D.AddForce(direction * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.CompareTag("Enemie"))
        {
           // other.gameObject.GetComponent<SlimeEnemieSystem>().health - Damage;
        }
        Destroy(this.gameObject);
      
    }
}
