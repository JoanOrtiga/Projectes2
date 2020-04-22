using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModifier : MonoBehaviour
{
    public int HealAmmount;
    private int hp;
    public float  healingVelocity;
    private float healingVelocitySaved;
    // Start is called before the first frame update
    
    void Start()
    {
        healingVelocitySaved = healingVelocity;
        hp = gameObject.GetComponent<PlayerController>().currentHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        healingVelocity -= Time.deltaTime;
        if (other.CompareTag("JumpActivator"))
        {
            this.gameObject.GetComponent<PlayerController>().jumpPlayer=true;
           
           
        }
        if (other.CompareTag("HealMe"))
        {
            if (hp != gameObject.GetComponent<PlayerController>().maxHP)
            {
                if (healingVelocity > 0)
                {
                    hp += HealAmmount;
                    healingVelocity = healingVelocitySaved;
                }


            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("JumpActivator"))
        {
            this.gameObject.GetComponent<PlayerController>().jumpPlayer=false;

        }
        if (other.CompareTag("HealMe"))
        {

        }
    }
}
