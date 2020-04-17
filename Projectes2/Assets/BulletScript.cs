using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int BulletSpeed;
    private Vector3 forward;
    public List<GameObject> stain;
    private GameObject stainToSpawn;
    int r ;
    // Start is called before the first frame update
    void Start()
    {
        //Random.InitState(System.Environment.TickCount);

        forward = new Vector3(0, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(forward * BulletSpeed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Hitable"))
        {
            StainSelector();
            Instantiate(stainToSpawn, this.gameObject.transform.position,this.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    void StainSelector()
    {
        r = Random.Range(0,3);

        stainToSpawn = stain[r];
    }
}
