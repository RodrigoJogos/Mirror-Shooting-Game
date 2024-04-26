using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_Gun : NetworkBehaviour
{
    // Inputs  
    private Player_Inputs player_Inputs;
    
    private Gun_Settings gun_settings;
   

    void Start()
    {
        player_Inputs = GetComponentInParent<Player_Inputs>();

        gun_settings = GetComponent<Gun_Settings>();
    }


    void Update()
    {
        if (!isLocalPlayer) return;
        
        //SHOOT ACTION ===========================================================================================

        if (player_Inputs.Set_LeftClick() && Time.time >= gun_settings.gun.next_fire_time)
        {
            gun_settings.Shoot();
        }

        //RELOAD ACTION ===========================================================================================
        if (player_Inputs.Set_Reload() && !gun_settings.gun.is_reloading)
        {
            gun_settings.Call_Reload();
        }

    }

    

}


