using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Upgrades_System : NetworkBehaviour
{
    [Header("HUD")]
    [SerializeField] private GameObject hud_upgrades;

    [Header("Gun Ammo")]
    [SerializeField] private Gun_Settings my_gun;

    [Header("Damage")]
    [SerializeField] private Pool_Controller pool_Controller;
    private Shoots_Upgrade shoots_upgrade;




    void Start() =>  Invoke("Get_Variable_Reference",5f);

    void Get_Variable_Reference() => shoots_upgrade = pool_Controller.Get_Shoots_Upgrade_Reference();


    // GUN AMMO
    [Command]
    public void Cmd_Upgrade_OriginalAmmo() => Clients_Upgrade_OriginalAmmo();

    [ClientRpc]
    public void Clients_Upgrade_OriginalAmmo()
   {
        my_gun.gun.Increase_ClipAmmo();
   }


   
    //DAMAGE
    [Command]
   public void Cmd_Upgrade_Damage() => shoots_upgrade.Change_Shoots_Damage();





    public void Set_Upgrade_Hud(bool _active_state)
    {
        hud_upgrades.SetActive(_active_state);
    }

}
