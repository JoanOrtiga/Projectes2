using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationGun : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        float rot = transform.rotation.eulerAngles.y;


        Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(Quaternion.Euler(transform.rotation.eulerAngles.x, rot, transform.rotation.eulerAngles.z), rotation, 10000f);
    }
}
