using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBoss : MonoBehaviour
{
    public float floatSpan = 2.0f;
    public float speed = 1.0f;

    private float startY;

    private bool moving = true;
    private bool goUp = false;
    public GameObject reference;

    void Start()
    {
        startY = transform.position.y;
        StartCoroutine(ChangePlatform());
        
    }

    void Update()
    {
        if (moving)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, (float)(startY + Mathf.Sin(Time.time * speed) * floatSpan / 2.0)), 0.05f);
        } 
        else if(!goUp && !moving)
        {
            transform.position = Vector2.Lerp(transform.position, reference.transform.position, 0.05f);
            
            if ((transform.position - reference.transform.position).sqrMagnitude <= 0.2)
            {
                StartCoroutine(UpPlatform());
            }
        }
        else if (goUp && !moving)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, startY), 0.05f);
            
            if ((transform.position - new Vector3(transform.position.x, startY)).sqrMagnitude <= 0.2)
            {
                StartCoroutine(ChangePlatform());
            }
        }
    }

    IEnumerator ChangePlatform()
    {
        moving = true;
        goUp = false;
        yield return new WaitForSeconds(Random.Range(5,15));
        moving = false;
        
    }
    IEnumerator UpPlatform()
    {
        yield return new WaitForSeconds(Random.Range(5,15));
        goUp = true;
    }
}
