using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    public int BulletSpeed;
    private Vector3 forward;
    // Start is called before the first frame update
    void Start()
    {
        forward = new Vector3(-1, -1, 0);
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
                      Destroy(this.gameObject);
        }
    }
}
