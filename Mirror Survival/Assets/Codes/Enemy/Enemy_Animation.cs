using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class Enemy_Animation : NetworkBehaviour
{
    private Animator anim;

    void Awake() => anim = GetComponent<Animator>();

    public void Run_Attack_Animation(float _distance_from_target)
    {
        anim.SetFloat("_distance", _distance_from_target);
    }

    public void Die_Animation(bool _live_situation)
    {
        anim.SetBool("_isAlive", _live_situation);
    }

}
