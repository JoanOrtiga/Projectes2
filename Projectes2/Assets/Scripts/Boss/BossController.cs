using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BossStates
{
    FollowPlayer, AtakBarrido, AtakBomb, AtakOrbitalStrike, KamikazePlayer
}
public class BossController : MonoBehaviour
{
    Rigidbody2D rb2d;

    protected float StartY= 9.5f;
    protected float StartX = 6.28f;
    protected float EndX = 32.55f;
    public float HP;
    public float maxHP;
    protected float bSpeed=10f;

    [SerializeField]
    private Image hpBar;
    public float lerpHpBar = 0.1f;
    
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // GetComponent<FollowPlayer>().enabled = true;
        //GetComponent<AtakBarrido>().enabled = true;
        //GetComponent<KamikazePlayer>().enabled = true;
        //GetComponent<AtakOrbitalStrike>().enabled = true;
        GetComponent<AtakBomb>().enabled = true;

        maxHP = HP;

    }

    private void Update()
    {
        hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, HP / maxHP, lerpHpBar);
        
        if (Input.GetKeyDown(KeyCode.N))
        {
            GetComponent<AtakBarrido>().enabled = false;
            GetComponent<AtakBomb>().enabled = false;
            GetComponent<AtakOrbitalStrike>().enabled = false;
            GetComponent<FollowPlayer>().enabled = false;
            GetComponent<KamikazePlayer>().enabled = false;

            GetComponent<AtakOrbitalStrike>().enabled = true;
        }


       if(HP <= 0)
        {
            hpBar.fillAmount = 0;

            SceneManager.LoadScene(0);
            Destroy(gameObject); 
        }
    }

    protected void changeMov(BossStates state)
    {
        BossStates next = state;
      
        while (next == state)
        {
            next = (BossStates)Random.Range(0, 5);
        }

        GetComponent<AtakBarrido>().enabled = false;
        GetComponent<AtakBomb>().enabled = false;
        GetComponent<AtakOrbitalStrike>().enabled = false;
        GetComponent<FollowPlayer>().enabled = false;
        GetComponent<KamikazePlayer>().enabled = false;


        switch (next)
        {
            case BossStates.AtakBarrido:
                GetComponent<AtakBarrido>().enabled = true;
                break;
            case BossStates.AtakBomb:
                GetComponent<AtakBomb>().enabled = true;
                break;
            case BossStates.AtakOrbitalStrike:
                GetComponent<AtakOrbitalStrike>().enabled = true;
                break;
            case BossStates.FollowPlayer:
                GetComponent<FollowPlayer>().enabled = true;
                break;
            case BossStates.KamikazePlayer:
                GetComponent<KamikazePlayer>().enabled = true;
                break;
        }
    }
}

