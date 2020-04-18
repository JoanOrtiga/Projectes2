using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    public int BulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * BulletSpeed * Time.deltaTime);

    }
    void OnCollisionEnter2D(Collision2D other)
    {
               
         Destroy(this.gameObject);
    }
}
