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
            print("HIT ENEMIE");
            if (other.gameObject.name == "FlyingEnemie")
            {
                print("HIT FLYING ALEIN");
                other.gameObject.GetComponent<FlyingEnemie>().HP = other.gameObject.GetComponent<FlyingEnemie>().HP - Damage;
            }
            else if(other.gameObject.name == "meleEnemie")
            {
                print("HIT MELE ENEMIE");

                this.gameObject.transform.GetChild(0).GetComponent<MeleEnemie>().health = other.gameObject.GetComponentInChildren<MeleEnemie>().health - Damage;

            }
            else if (other.gameObject.name == "shootingAlien")
            {
                print("HIT BASIC ENEMIE");

                other.gameObject.GetComponent<StandardEnemie>().HP = other.gameObject.GetComponent<StandardEnemie>().HP - Damage;

            }

            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
      
    }
}
