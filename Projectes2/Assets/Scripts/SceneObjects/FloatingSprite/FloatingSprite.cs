using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingSprite : MonoBehaviour
{

    public float floatSpan = 2.0f;
    public float speed = 1.0f;

    private float startY;
    private Sprite originalHand;
 
    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, (float)(startY + Mathf.Sin(Time.time * speed) * floatSpan / 2.0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
