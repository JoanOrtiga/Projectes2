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
        currentBomb = 0;
    }
    private void Update()
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
