using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtakOrbitalStrike : BossController
{

    public GameObject OrbitalP1, OrbitalP2, OrbitalP3;
    public GameObject OrbitalAtack;


    private bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FireRate());
    }
    IEnumerator FireRate()
    {
        canShoot = false;
        InstaniateProjectile();
        yield return new WaitForSeconds(5f);
        canShoot = true;
    }
    void InstaniateProjectile()
    {
        Instantiate(OrbitalAtack, transform.position, transform.rotation);

    }
}
