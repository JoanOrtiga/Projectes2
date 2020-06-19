using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public GameObject manaManager;

    public GameObject paintWheel;
    public List<GameObject> Bala;
    public Transform shotPoint;
    public Transform shotPoint1;
    public Transform shotPoint2;

    public GameObject light1;
    public GameObject light2;

    [SerializeField] private GameObject leftGun;
    [SerializeField] private GameObject rightGun;



    public int DPSMana;
    public int HealMana;
    public int PortalMana;
    public int JumpBullet;
    public int TimeBullet;


    public GameObject GunLimb;

    private AudioManager audioManager;

    public float bulletStrenght = 50f;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {

        PaintColors rightColor = paintWheel.GetComponent<PaintWheel>().rightPaint;


        PaintColors leftColor = paintWheel.GetComponent<PaintWheel>().leftPaint;

        switch (rightColor)
        {
            case PaintColors.red:
                Debug.Log("no hay arma de este color");
                break;
            case PaintColors.cyan:
                Debug.Log("no hay arma de este color");
                break;
            case PaintColors.blue:
                rightGun = Bala[2];
                break;
            case PaintColors.yellow:
                Debug.Log("no hay arma de este color");
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
                rightGun = Bala[3];
                break;
            default:
                rightGun = Bala[5];
                break;
        }
        switch (leftColor)
        {
            case PaintColors.red:
                Debug.Log("no hay arma de este color");
                break;
            case PaintColors.cyan:
                Debug.Log("no hay arma de este color");
                break;
            case PaintColors.blue:
                leftGun = Bala[2];
                break;
            case PaintColors.yellow:
                Debug.Log("no hay arma de este color");
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
                leftGun = Bala[3];
                break;
            default:
                leftGun = Bala[5];
                break;
        }

        

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shotPoint.position;
        difference.Normalize();


        if (GetComponentInParent<PlayerMovement>().facingDirection == -1)
        {
            GetComponentInChildren<SpriteRenderer>().flipY = true;
            shotPoint = shotPoint2;
            light1.SetActive(false);
            light2.SetActive(true);
            
        }
        else if (GetComponentInParent<PlayerMovement>().facingDirection == 1)
        {
            GetComponentInChildren<SpriteRenderer>().flipY = false;
            shotPoint = shotPoint1;
            light1.SetActive(true);
            light2.SetActive(false);
        }

        if (paintWheel.GetComponent<PaintWheel>().shootable)
        {
            //left mouse button
            if (Input.GetMouseButtonDown(0))
            {
                //GameObject bulletLeft = Instantiate(leftGun, shotPoint.position, shotPoint.rotation);
                //bulletLeft.GetComponent<Rigidbody2D>().velocity = shotPoint.TransformDirection(new Vector3(0, 0, 4));
                //GameObject bulletLeft = Instantiate(leftGun, shotPoint.position, shotPoint.rotation);
                //bulletLeft.GetComponent<Rigidbody2D>().velocity = difference * bulletStrenght;
                if (leftGun == Bala[5])
                {
                    GameObject bulletLeft = Instantiate(leftGun, shotPoint.position, shotPoint.rotation);
                    bulletLeft.GetComponent<Rigidbody2D>().velocity = bulletLeft.GetComponent<Rigidbody2D>().transform.right * -1 * bulletStrenght;
                }
                else if (leftGun == Bala[0] && manaManager.GetComponent<StainManager>().manaMana >= DPSMana)
                {
                    GameObject bulletLeft = Instantiate(leftGun, shotPoint.position, shotPoint.rotation);
                    bulletLeft.GetComponent<Rigidbody2D>().velocity = bulletLeft.GetComponent<Rigidbody2D>().transform.right * -1 * bulletStrenght;
                    manaManager.GetComponent<StainManager>().manaCalculator(false, DPSMana);

                }
                else if (leftGun == Bala[1] && manaManager.GetComponent<StainManager>().manaMana >= HealMana)
                {
                    GameObject bulletLeft = Instantiate(leftGun, shotPoint.position, shotPoint.rotation);
                    bulletLeft.GetComponent<Rigidbody2D>().velocity = bulletLeft.GetComponent<Rigidbody2D>().transform.right * -1 * bulletStrenght;
                    manaManager.GetComponent<StainManager>().manaCalculator(false, HealMana);
                }
                else if (leftGun == Bala[2] && manaManager.GetComponent<StainManager>().manaMana >= PortalMana)
                {
                    GameObject bulletLeft = Instantiate(leftGun, shotPoint.position, shotPoint.rotation);
                    bulletLeft.GetComponent<Rigidbody2D>().velocity = bulletLeft.GetComponent<Rigidbody2D>().transform.right * -1 * bulletStrenght;
                    manaManager.GetComponent<StainManager>().manaCalculator(false, PortalMana);

                }
                else if (leftGun == Bala[3] && manaManager.GetComponent<StainManager>().manaMana >= JumpBullet)
                {
                    GameObject bulletLeft = Instantiate(leftGun, shotPoint.position, shotPoint.rotation);
                    bulletLeft.GetComponent<Rigidbody2D>().velocity = bulletLeft.GetComponent<Rigidbody2D>().transform.right * -1 * bulletStrenght;
                    manaManager.GetComponent<StainManager>().manaCalculator(false, JumpBullet);

                }
                else if (leftGun == Bala[4] && manaManager.GetComponent<StainManager>().manaMana >= TimeBullet)
                {
                    GameObject bulletLeft = Instantiate(leftGun, shotPoint.position, shotPoint.rotation);
                    bulletLeft.GetComponent<Rigidbody2D>().velocity = bulletLeft.GetComponent<Rigidbody2D>().transform.right * -1 * bulletStrenght;
                    manaManager.GetComponent<StainManager>().manaCalculator(false, TimeBullet);
                }

            }


            //right mouse button
            if (Input.GetMouseButtonDown(1))
            {
<<<<<<< HEAD

                
=======
>>>>>>> 836c13becefd5f7d97970b24a3b0e1add5720c28
                if(audioManager!=null)
                    audioManager.Play("PlayerAtack");
                //GameObject bulletRight = Instantiate(rightGun, shotPoint.position, shotPoint.rotation);
                //bulletRight.GetComponent<Rigidbody2D>().velocity = difference * bulletStrenght;

                if (rightGun == Bala[5])
                {
                    GameObject bulletRight = Instantiate(rightGun, shotPoint.position, shotPoint.rotation);
                    bulletRight.GetComponent<Rigidbody2D>().velocity = bulletRight.GetComponent<Rigidbody2D>().transform.right * -1 * bulletStrenght;

                }
                else if (rightGun == Bala[0] && manaManager.GetComponent<StainManager>().manaMana >= DPSMana)
                {
                    GameObject bulletRight = Instantiate(rightGun, shotPoint.position, shotPoint.rotation);
                    bulletRight.GetComponent<Rigidbody2D>().velocity = bulletRight.GetComponent<Rigidbody2D>().transform.right * -1 * bulletStrenght;
                    manaManager.GetComponent<StainManager>().manaCalculator(false, DPSMana);

                }
                else if (rightGun == Bala[1] && manaManager.GetComponent<StainManager>().manaMana >= HealMana)
                {
                    GameObject bulletRight = Instantiate(rightGun, shotPoint.position, shotPoint.rotation);
                    bulletRight.GetComponent<Rigidbody2D>().velocity = bulletRight.GetComponent<Rigidbody2D>().transform.right * -1 * bulletStrenght;
                    manaManager.GetComponent<StainManager>().manaCalculator(false, HealMana);
                }
                else if (rightGun == Bala[2] && manaManager.GetComponent<StainManager>().manaMana >= PortalMana)
                {
                    GameObject bulletRight = Instantiate(rightGun, shotPoint.position, shotPoint.rotation);
                    bulletRight.GetComponent<Rigidbody2D>().velocity = bulletRight.GetComponent<Rigidbody2D>().transform.right * -1 * bulletStrenght;
                    manaManager.GetComponent<StainManager>().manaCalculator(false, PortalMana);

                }
                else if (rightGun == Bala[3] && manaManager.GetComponent<StainManager>().manaMana >= JumpBullet)
                {
                    GameObject bulletRight = Instantiate(rightGun, shotPoint.position, shotPoint.rotation);
                    bulletRight.GetComponent<Rigidbody2D>().velocity = bulletRight.GetComponent<Rigidbody2D>().transform.right * -1 * bulletStrenght;
                    manaManager.GetComponent<StainManager>().manaCalculator(false, JumpBullet);

                }
                else if (rightGun == Bala[4] && manaManager.GetComponent<StainManager>().manaMana >= TimeBullet)
                {
                    GameObject bulletRight = Instantiate(rightGun, shotPoint.position, shotPoint.rotation);
                    bulletRight.GetComponent<Rigidbody2D>().velocity = bulletRight.GetComponent<Rigidbody2D>().transform.right * -1 * bulletStrenght;
                    manaManager.GetComponent<StainManager>().manaCalculator(false, TimeBullet);

                }
            }
        }
    }
}
