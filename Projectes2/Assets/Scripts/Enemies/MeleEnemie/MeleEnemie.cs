using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemie : MonoBehaviour
{
    public float speed = 3f;
    private Vector2[] patrolPoints;
    public float distance = 10f;

    private Vector2 enemiePosition;
    
    void Start()
    {
        patrolPoints[0] = new Vector2(this.transform.position.x + distance , this.transform.position.y);
        patrolPoints[1] = new Vector2(this.transform.position.x - distance , this.transform.position.y);

        enemiePosition = new Vector2(this.transform.position.x, this.transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0], speed * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        print(patrolPoints[0]);
        print(patrolPoints[1]);
        print(enemiePosition);

        if (enemiePosition.x > patrolPoints[0].x)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1], speed * Time.deltaTime);
        }
        else if (enemiePosition.x < patrolPoints[0].x)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0], speed * Time.deltaTime);
        }
    }
}
