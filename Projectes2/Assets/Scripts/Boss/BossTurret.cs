using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.Mathematics;
using UnityEngine;

public class BossTurret : MonoBehaviour
{
    public GameObject shootPoint;
    private Transform player;
    public GameObject bullet;
    //vectors
    private Vector3 thisPos;
    private Vector3 targetPos;

    //float
    public float shootIntervall;
    public float bulletSpeed;
    public float BulletTimer;
    public float offset;
    private float angle;

    //booleans
    public bool awake;

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void LateUpdate()
    {
        targetPos = player.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
       
    }
    private void Update()
    {
        if (awake)
            Attack();
    }
    public void Attack()
    {
        BulletTimer += Time.deltaTime;
        if (BulletTimer >= shootIntervall)
        {
            Vector2 direction = player.position - transform.position;
            GameObject bulletClone;
            bulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            BulletTimer = 0;
        }
    }
}
