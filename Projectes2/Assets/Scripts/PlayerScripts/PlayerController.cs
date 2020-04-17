using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float Speed = 10f;

    private SpriteRenderer thisSprite;

    private void Start()
    {
        thisSprite = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float DirctionX = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + DirctionX, transform.position.y);



        if (Input.GetAxis("Horizontal") < -0.1)
        {
            thisSprite.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0.1)
        {
            thisSprite.flipX = false;
        }
    }


}
