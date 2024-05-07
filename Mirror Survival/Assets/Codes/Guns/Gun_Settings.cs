using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Gun_Settings : NetworkBehaviour
{
    private Pool_Controller pool_controller;  
      
    [SerializeField] private Transform origin_shoot;
    public Transform Origin_Shoot {get {return origin_shoot;} }

 
    [Header("Holding Gun")]    
    public Guns gun;
    [SerializeField] private Gun_Data gun_data;
    [SerializeField] private PlayersLocal_Hud gun_hud;


    [Header("Audio")]    
    private Player_Sounds player_sounds;
   


    void Start()
    {
        pool_controller = GetComponent<Pool_Controller>();
        player_sounds = GetComponent<Player_Sounds>();

        //Create First Gun
        gun  = new Guns(gun_data);
        Change_Gun_Hud();
    }


    public void Change_Gun_Hud() => gun_hud.Set_Gun(gun.icon_hud, gun.ammo);


    //SHOOTING MECANISM ===========================================================================================

    public void Shoot()
    {
        gun.next_fire_time = Time.time + gun.fireRate;

        if (gun.ammo > 0)
        {
            pool_controller.Cmd_Get_Index_Pool();

            player_sounds.Stop_Pistol_Shoot_Sound();
            gun.ammo--;
            gun_hud.Set_Ammo(gun.ammo);

            player_sounds.Pistol_Shoot_Sound();
           
           if (gun.ammo < 1)
           {
                player_sounds.Stop_Pistol_Shoot_Sound();
                Call_Reload();
           }
        }
       
    }


   //RELOADING MECANISM  ===========================================================================================

   public void Call_Reload() => StartCoroutine(Reload());

    public IEnumerator Reload()
    {
        gun.ammo = 0;
        gun.is_reloading = true;
        player_sounds.Pistol_Reloading_Sound();
        yield return new WaitForSeconds(gun.reloading_clip.length);
        gun.ammo = gun.original_ammo;
        gun_hud.Set_Ammo(gun.ammo);
        gun.is_reloading = false;
    }

    
}
