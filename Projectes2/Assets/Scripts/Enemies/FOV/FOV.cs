using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public float visionRadius;
    public float attackRadius;


    GameObject player;
    GameObject enemie;
    Rigidbody2D rb2d;

    Vector3 initalPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        

        initalPosition = transform.position;

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = initalPosition;

        RaycastHit2D hit = Physics2D.Raycast( // comproba entre el enemigo, y el player
            transform.position, //posicion enemigo
            player.transform.position - transform.position, //vector mirando el jugador
            visionRadius, //vision 
            1 << LayerMask.NameToLayer("Player") | LayerMask.NameToLayer("Ground"));

        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        //Debug.DrawRay(transform.position, forward, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                target = player.transform.position;
                Debug.DrawLine(transform.position, target, Color.green);

            }
        }

        float distace = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

        


        if (target != initalPosition && distace < attackRadius)
        {
            print("shoot");
            this.gameObject.GetComponent<StandardEnemie>().Shoot();

        }

        if (target != initalPosition && distace < visionRadius && distace > attackRadius)
        {
            print("Chase");
            this.gameObject.GetComponent<StandardEnemie>().Attack(true);

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
