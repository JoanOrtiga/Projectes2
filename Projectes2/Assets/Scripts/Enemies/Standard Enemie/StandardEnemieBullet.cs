using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemieBullet : MonoBehaviour
{
    public int DMG = 3;
    public float speed = 3f;
    private Transform player;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        Destroy(this.gameObject, 2);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<PlayerController>().currentHP -= DMG;
        Destroy(this.gameObject);
    }
}
