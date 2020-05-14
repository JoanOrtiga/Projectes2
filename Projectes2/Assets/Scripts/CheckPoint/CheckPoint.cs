using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{
    GameObject manager;
    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("CheckManager");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            manager.GetComponent<CheckPointManager>().GetCheckPoint(transform.position);
            gameObject.SetActive(false);
        }
        
    }
}
