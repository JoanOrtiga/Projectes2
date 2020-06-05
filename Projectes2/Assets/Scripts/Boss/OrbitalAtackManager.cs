using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalAtackManager : MonoBehaviour
{
    private float time;
    public float damage;
    private void Start()
    {
        time = 2;
    }
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().currentHP -= damage * Time.deltaTime;
        }
    }

}
