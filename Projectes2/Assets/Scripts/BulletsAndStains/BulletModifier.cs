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
        print(other.name);
        if (other.CompareTag("HealMe"))
        {
            print("hola");
            if (gameObject.GetComponent<PlayerHealth>().currentHP < gameObject.GetComponent<PlayerHealth>().maxHP)
            {
                print(HealAmmount * Time.deltaTime);
                
                gameObject.GetComponent<PlayerHealth>().currentHP += (HealAmmount * Time.deltaTime);
            }
        }
    }
}
