using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject paintWheel;
    public List<GameObject> Bala;
    public Transform shotPoint;
    [SerializeField] private GameObject leftGun;
    [SerializeField] private GameObject rightGun;
    private Transform myTransform;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
       
        PaintColors rightColor = paintWheel.GetComponent<PaintWheel>().rightPaint;

      
        PaintColors leftColor = paintWheel.GetComponent<PaintWheel>().leftPaint;

        switch (rightColor)
        {
            case PaintColors.red:
                rightGun = Bala[0];
                break;
            case PaintColors.cyan:
                rightGun = Bala[1];
                break;
            case PaintColors.blue:
                rightGun = Bala[2];
                break;
            case PaintColors.yellow:
                rightGun = Bala[3];
                break;
            case PaintColors.orange:
                rightGun = Bala[4];
                break;
            case PaintColors.pink:
                rightGun = Bala[5];
                break;
            case PaintColors.darkBlue:
                Debug.Log("no hay arma de este color");
                break;
            case PaintColors.green:
                Debug.Log("no hay arma de este color");
                break;
            default:
                rightGun = Bala[5];
                break;
        }
        switch (leftColor)
        {
            case PaintColors.red:
                leftGun = Bala[0];
                break;
            case PaintColors.cyan:
                leftGun = Bala[1];
                break;
            case PaintColors.blue:
                leftGun = Bala[2];
                break;
            case PaintColors.yellow:
                leftGun = Bala[3];
                break;
            case PaintColors.orange:
                leftGun = Bala[4];
                break;
            case PaintColors.pink:
                leftGun = Bala[5];
                break;
            case PaintColors.darkBlue:
                Debug.Log("no hay arma de este color");
                break;
            case PaintColors.green:
                Debug.Log("no hay arma de este color");
                break;
            default:
                leftGun = Bala[5];
                break;
        }

        
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);


        if (paintWheel.GetComponent<PaintWheel>().shootable)
        {     
            //left mouse button
            if (Input.GetMouseButtonDown(0))
            {
                //GameObject bulletLeft = Instantiate(leftGun, shotPoint.position, shotPoint.rotation);
                //bulletLeft.GetComponent<Rigidbody2D>().velocity = shotPoint.TransformDirection(new Vector3(0, 0, 4));
                GameObject bulletLeft = Instantiate(leftGun, shotPoint.position, shotPoint.rotation);
                bulletLeft.GetComponent<Rigidbody2D>().velocity = difference * 15f;
                if (leftGun == Bala[5])
                {
                    bulletLeft.GetComponent<NormalBullet>().direction = difference;
                   
                }
                else
                {
                    bulletLeft.GetComponent<BulletScript>().direction = difference;
                }
            }


            //right mouse button
            if (Input.GetMouseButtonDown(1))
            {
                GameObject bulletRight = Instantiate(rightGun, shotPoint.position, shotPoint.rotation);
                bulletRight.GetComponent<Rigidbody2D>().velocity = difference * 15f;

                if (rightGun == Bala[5])
                {
                    bulletRight.GetComponent<NormalBullet>().direction = difference;
                    
                }
                else
                {
                    bulletRight.GetComponent<BulletScript>().direction = difference;

                }
            }
        }
    }
}
