using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtakBomb : BossController
{
    public float fireDelay;
    private float fireDelaySeconds;
    [SerializeField]
    private List<GameObject> Points;
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;

    private bool canMove;

    private GameObject bombShooter;
    public GameObject bomb;

    private int index;

    public int maxBombs;
    private int currentBomb;
    private void Start()
    {
        fireDelaySeconds = 2;
        Points.Add(SpawnPoint1);
        Points.Add(SpawnPoint2);
        Points.Add(SpawnPoint3);
    }
    private void OnEnable()
    {
        canMove = true;
        currentBomb = 0;
    }
    private void Update()
    {
        if (!canMove)
        {
            fireDelaySeconds -= Time.deltaTime;
            if (currentBomb == maxBombs)
            {
                ChangeState();
            }
            if (fireDelaySeconds <= 0)
            {
                index = Random.Range(0, Points.Count);
                bombShooter = Points[index];
                fire();
                fireDelaySeconds = fireDelay;

            }
        }
        
       
    }

    private void FixedUpdate()
    {
        if (transform.position.y == StartY)
        {
            canMove = false;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(transform.position.x, StartY, transform.position.z), bSpeed * Time.deltaTime);
        }
    }


    void fire()
    {
        Instantiate(bomb, bombShooter.transform.position, Quaternion.identity);
        currentBomb++;
    }
    public void ChangeState()
    {
        changeMov(BossStates.AtakBomb);

    }

}
