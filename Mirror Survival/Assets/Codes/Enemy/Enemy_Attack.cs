using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Enemy_Attack : NetworkBehaviour
{
    [SerializeField] private BoxCollider _collider;


    public void Enabled_Collider_Attack()
    {
        _collider.enabled = true;
    }

    public void Disable_Collider_Attack()
    {
        _collider.enabled = false;
    }

}
