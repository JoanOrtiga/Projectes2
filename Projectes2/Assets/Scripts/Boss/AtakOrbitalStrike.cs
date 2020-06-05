using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtakOrbitalStrike : BossController
{
    [SerializeField]
    private List<GameObject> Points;
    public GameObject OrbitalP1, OrbitalP2, OrbitalP3;
    public GameObject OrbitalAtack;
    private bool orbitalPointReached;
    private GameObject OrbitalPChoosed;
    int index;
    public int movementSpeed;
    public GameObject shootPoint;
    private float time;

    // Start is called before the first frame update
    private void Start()
    {
        Points.Add(OrbitalP1);
        Points.Add(OrbitalP2);
        Points.Add(OrbitalP3);
    }
    private void OnEnable()
    {
        orbitalPointReached = false;
        
        OrbitalPChoosed = null;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (orbitalPointReached)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                ChangeState();

            }
        }
        else
        {
            if (OrbitalPChoosed == null)
            {
                index = Random.Range(0, Points.Count);
                OrbitalPChoosed = Points[index];
            }


            if ((OrbitalPChoosed.transform.position - transform.position).magnitude <= 0.8f)
            {
                InstaniateProjectile();
                orbitalPointReached = true;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, OrbitalPChoosed.transform.position, movementSpeed * Time.deltaTime);

            }
        }
    }
   
    void InstaniateProjectile()
    {
        Instantiate(OrbitalAtack, shootPoint.transform.position, shootPoint.transform.rotation);
        time = 2;

    }
    
    public void ChangeState()
    {
        changeMov(BossStates.AtakOrbitalStrike);

    }

}
