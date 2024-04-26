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
    public Gun_Data gun_data;
    public PlayersLocal_Hud gun_hud;



    void Start()
    {
        pool_controller = GetComponent<Pool_Controller>();
        
        //Create First Gun
        gun  = new Guns(gun_data);

        Change_Gun_Hud();
    }

    public void Change_Gun_Hud()
    {
        gun_hud.Set_Gun(gun.icon_hud, gun.ammo);
    }

    //SHOOTING MECANISM ===========================================================================================

    public void Shoot()
    {
        gun.next_fire_time = Time.time + gun.fireRate;

        if (gun.ammo > 0)
        {
            gun.ammo--;
            gun_hud.Set_Ammo(gun.ammo);

            pool_controller.Cmd_Get_Index_Pool();
           
           if (gun.ammo < 1)
           {
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
        yield return new WaitForSeconds(gun.reloading_clip.length);
        gun.ammo = gun.original_ammo;
        gun_hud.Set_Ammo(gun.ammo);
        gun.is_reloading = false;
    }

    
}
