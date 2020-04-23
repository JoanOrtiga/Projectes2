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
        
        if (other.gameObject.CompareTag("Hitable"))
        {
            StainSelector();
            GameObject newstain = Instantiate(stainToSpawn, this.gameObject.transform.position,this.gameObject.transform.rotation);
            print(manager);
            print(manager.GetComponent<StainManager>());
            print(newstain);
            print(newstain.GetComponent<StainColors>().stainColor);

            manager.GetComponent<StainManager>().newStain(newstain, newstain.GetComponent<StainColors>().stainColor);
           
            Destroy(this.gameObject);
        }
    }

    void StainSelector()
    {
        r = Random.Range(0,3);

        stainToSpawn = stain[r];
    }
}
