using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_Animations : NetworkBehaviour
{
    private Player_Inputs player_Inputs;

    private Gun_Settings gun_Settings;

    private Life_System life_System;

    public Animator anim;


    void OnEnable()
    {
        life_System.Set_Alive_State(true);
        GetComponent<Player_Movement>().enabled = true;
        GetComponent<Player_Rotation>().enabled = true;
        player_Inputs.enabled = true;
    } 


    void Awake()
    {
        anim = GetComponent<Animator>();
        gun_Settings = GetComponentInChildren<Gun_Settings>();
        life_System = GetComponent<Life_System>();
        player_Inputs = GetComponentInParent<Player_Inputs>();
    }


     void Update()
    {
        if (isLocalPlayer)
        {
            Die_Animation(life_System.Get_Alive_State());

            if (life_System.Get_Alive_State())
            {
                Movement_Animation(player_Inputs.Set_Movement().x,player_Inputs.Set_Movement().z);

                Shooting_Animation(player_Inputs.Set_LeftClick());

                Reloading_Animation(gun_Settings.gun.is_reloading);
            }  
        }
    }

    void Shooting_Animation(bool _shoot_state)
    {
        anim.SetBool("is_shooting",_shoot_state);
    }

    void Reloading_Animation(bool _reload_state)
    {
        anim.SetBool("is_reloading",_reload_state);
    }


    void Movement_Animation(float _x_input, float _z_input)
    {
        if (_x_input != 0f || _z_input != 0f)
        {
            anim.SetBool("is_moving",true);
            return;
        }

        anim.SetBool("is_moving",false);

    }
    

    void Die_Animation(bool _live_situation)
    {
        anim.SetBool("_isAlive", _live_situation);
    }

    public void DieController()
    {
        GetComponent<Player_Movement>().enabled = false;
        GetComponent<Player_Rotation>().enabled = false;
        player_Inputs.enabled = false;
    }
}
