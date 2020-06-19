using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtakBomb : BossController
{
    public float fireDelay;
    private float fireDelaySeconds;
    private float SelectedPos;
    [SerializeField]
    private List<GameObject> Points;
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;

    private bool canMove;
    private bool posChossen;

    private GameObject bombShooter;
    public GameObject bomb;
    private AudioManager audioManager;

    private int index;

    public int maxBombs;
    private int currentBomb;
    private void Start()
    {
        fireDelaySeconds = 2;
        Points.Add(SpawnPoint1);
        Points.Add(SpawnPoint2);
        Points.Add(SpawnPoint3);
        audioManager = FindObjectOfType<AudioManager>();

    }
    private void OnEnable()
    {
        canMove = true;
        currentBomb = 0;
        posChossen = true;
    }
    private void OnDisable()
    {
        canMove = false;
        currentBomb = 0;
        posChossen = true;
    }
    private void Update()
    {
        if (!canMove)
        {
            fireDelaySeconds -= Time.deltaTime;
            if (currentBomb == maxBombs)
            {
                ChangeState();
            }
            if (fireDelaySeconds <= 0)
            {
                index = Random.Range(0, Points.Count);
                bombShooter = Points[index];
                fire();
                fireDelaySeconds = fireDelay;

            }
        }
        
       
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.y-StartY)<0.25)
        {
            if (Mathf.Abs(transform.position.x - SelectedPos) < 0.25) 
            {
                canMove = false;
            }
            else
            {
                if (posChossen)
                {
                    choosePos();
                    posChossen = false;
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector3(SelectedPos, transform.position.y, transform.position.z), bSpeed * Time.deltaTime);
                }
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(transform.position.x, StartY, transform.position.z), bSpeed * Time.deltaTime);
        }
    }
    void choosePos()
    {
        Mathf.Round(SelectedPos = Random.Range(StartX, EndX));

        SelectedPos -= 20;
    }


    void fire()
    {
        Instantiate(bomb, bombShooter.transform.position, Quaternion.identity);
        if(audioManager != null)
            audioManager.Play("BossBombDrop");
        currentBomb++;
    }
    public void ChangeState()
    {
        changeMov(BossStates.AtakBomb);

    }

}
