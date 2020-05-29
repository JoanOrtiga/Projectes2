using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BossStates
{
    FollowPlayer, AtakBarrido, AtakBomb, AtakOrbitalStrike, KamikazePlayer
}
public class BossController : BossState
{
    // Use this for initialization
    void Start()
    {
        GetComponent<FollowPlayer>().enabled = true;
    }

    protected BossStates switchMov()
    {
        
        

        return BossStates.FollowPlayer;
    }

    protected virtual void changeMov()
    {

    }
}
