using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFOV : MonoBehaviour
{
    public float distance = 5;

    private GameObject player;
    private Rigidbody2D rb2d;

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance); //from, what direction, distance

        if (hitInfo.collider != null) //in contect on smothing will trun red
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.red);
        }
    }
}
