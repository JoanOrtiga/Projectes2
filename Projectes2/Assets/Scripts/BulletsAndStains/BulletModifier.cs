using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModifier : MonoBehaviour
{
    public float HealAmmount;
    private int hp;
    private float healingVelocitySaved;
    // Start is called before the first frame update
    
    private void OnTriggerStay2D(Collider2D other)
    {
        

        if (other.CompareTag("JumpActivator"))
        {
            this.gameObject.GetComponent<PlayerController>().jumpPlayer=true;
           
           
        }

        if (other.CompareTag("HealMe"))
        {
          /*  if (gameObject.GetComponent<PlayerController>().currentHP < gameObject.GetComponent<PlayerController>().maxHP)
            {

                print(HealAmmount * Time.deltaTime);
                
                //gameObject.GetComponent<PlayerController>().currentHP += (HealAmmount * Time.deltaTime);
            }*/
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
