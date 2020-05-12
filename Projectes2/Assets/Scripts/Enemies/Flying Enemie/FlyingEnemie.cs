using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemie : MonoBehaviour
{
    public int hp = 10;
    public int DMG = 3;
    public float attackTime = 2;

    public float speed = 4f;

    private GameObject target;


    private float yValue;
    private float actualTime;

    // Start is called before the first frame update
    void Start()
    {
        yValue = this.transform.position.y;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        actualTime += Time.deltaTime;
        
        attack();
    }



    public void attack()
    {
        if (actualTime < attackTime)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        
    }
}
