using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("JumpActivator"))
        {
            this.gameObject.GetComponent<PlayerController>().JumpPlayer(true);
           
           
        }
        if (other.CompareTag("HealMe"))
        {

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("JumpActivator"))
        {
            this.gameObject.GetComponent<PlayerController>().JumpPlayer(false);

        }
        if (other.CompareTag("HealMe"))
        {

        }
    }
}
