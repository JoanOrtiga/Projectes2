using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    public int BulletSpeed;
    private Rigidbody2D rb2D;
    [HideInInspector] public Vector2 direction;
    public int Damage ;
    public Vector3 forward;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        rb2D.AddForce(direction * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.CompareTag("Enemie"))
        {
            if (other.gameObject.name == "Slime Enemie 1" || other.gameObject.name == "Slime Enemie 2(Clone)" || other.gameObject.name == "Slime Enemie 3(Clone)")
            {
                print("HIT SLIME");
                other.gameObject.GetComponent<SlimeEnemieSystem>().health = other.gameObject.GetComponent<SlimeEnemieSystem>().health - Damage;
            }
            else if(other.gameObject.name == "Mele Enemie")
            {
                print("HIT MELE ENEMIE");

                this.gameObject.transform.GetChild(0).GetComponent<MeleEnemie>().health = other.gameObject.GetComponent<MeleEnemie>().health - Damage;

            }
            else if (other.gameObject.name == "Basic Enemie")
            {
                print("HIT BASIC ENEMIE");

                other.gameObject.GetComponent<StandardEnemie>().health = other.gameObject.GetComponent<StandardEnemie>().health - Damage;

            }

            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
      
    }
}
