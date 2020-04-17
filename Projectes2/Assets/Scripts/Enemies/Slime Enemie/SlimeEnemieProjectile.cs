using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemieProjectile : MonoBehaviour
{
    public Transform throwPoint;

    public GameObject projectile;

    public float xVelo, yVelo;

    
    void Start()
    {
        Trow();
    }

    void Trow()
    {

        GameObject bulletInstace = Instantiate(projectile, throwPoint.position, Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
        Rigidbody2D rigid;
        rigid = bulletInstace.GetComponent<Rigidbody2D>();

        rigid.velocity = new Vector2(xVelo, yVelo);
    }
}
