using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckPoint : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.GetComponentInParent<CheckPointManager>().GetCheckPoint(transform.position);
            gameObject.SetActive(false);
        }
        
    }
}
