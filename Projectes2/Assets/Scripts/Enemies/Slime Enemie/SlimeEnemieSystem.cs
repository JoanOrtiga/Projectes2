using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemieSystem : MonoBehaviour
{
    public int heath = 10;

    public float chaseDistance = 10;
    public float attackDistance = 7;
    public float chaseSpeed = 4;

    private GameObject target;
    private float distance;

    public Transform[] spawnPoints;
    public GameObject[] enemie;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");


        if (transform.childCount > 1)
        {
            spawnPoints[0] = this.gameObject.transform.GetChild(0);
            spawnPoints[1] = this.gameObject.transform.GetChild(1);
        }
        else
        {
            print("THis slime has no childern");
        }

    }

    void Update()
    {
        print(distance);

        EnemieReproduction();
        StateMachineEnemie();
    }

    void EnemieReproduction()
    {
        if (enemie.Length == 0 && heath <= 0)
        {
            Destroy(this.gameObject);
        }
        else if (heath <= 0 && enemie.Length > 0)
        {
            Instantiate(enemie[0], spawnPoints[0].position, Quaternion.identity);
            Instantiate(enemie[0], spawnPoints[1].position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void StateMachineEnemie()
    {
        distance = (target.transform.position.x - transform.position.x);


        //chase
        if (distance <= chaseDistance && distance > attackDistance) 
        {
            this.gameObject.GetComponent<SlimeEnemieProjectile>().AttackState(false);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, chaseSpeed * Time.deltaTime);
        }

        //patrol
        else if (distance > chaseDistance)
        {
            print("Patrol");
        }

        //shoot
        else if (distance <= attackDistance)
        {
            print("Attack");
            this.gameObject.GetComponent<SlimeEnemieProjectile>().AttackState(true);
        }

       
    }


}
