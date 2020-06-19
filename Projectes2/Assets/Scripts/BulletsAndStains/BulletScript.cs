using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int BulletSpeed;
    public Vector3 forward;
    public List<GameObject> stain;
    private GameObject stainToSpawn;
    int r ;
    private Rigidbody2D rb2D;
    private GameObject manager;

    [HideInInspector] public Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        //Random.InitState(System.Environment.TickCount);
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        manager = GameObject.FindGameObjectWithTag("BulletManager");
    }

    // Update is called once per frame
    void Update()
    {
      // transform.Translate(transform.right * BulletSpeed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        //   rb2D.transform.Translate(transform.right * 1 * Time.deltaTime) ;
         rb2D.AddForce(direction * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("stairs"))
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());

        if (other.gameObject.CompareTag("Hitable"))
        {
            StainSelector();

            
            GameObject newstain = Instantiate(stainToSpawn, this.gameObject.transform.position, this.gameObject.transform.rotation);
            manager.GetComponent<StainManager>().newStain(newstain, newstain.GetComponent<StainColors>().stainColor);
            newstain.transform.parent = manager.transform;
        }
        else if (other.gameObject.CompareTag("HittablePlatform"))
        {
            StainSelector();

            GameObject newstain = Instantiate(stainToSpawn, this.gameObject.transform.position, this.gameObject.transform.rotation);
            manager.GetComponent<StainManager>().newStain(newstain, newstain.GetComponent<StainColors>().stainColor);
            newstain.transform.parent = manager.transform;
        }



        if (!other.gameObject.CompareTag("stairs"))
            Destroy(this.gameObject);
        else
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());

    }
    void StainSelector()
    {
        r = Random.Range(0,3);

        stainToSpawn = stain[r];
    }
}
