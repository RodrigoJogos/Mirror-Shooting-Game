using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class Shoots_Upgrade : NetworkBehaviour
{
    [SyncVar(hook = nameof(Damage_Changed))]public int current_damage = 1;

    private Pool_GameObjects shoots_pool;



    void Start() => shoots_pool = GetComponent<Pool_GameObjects>();



    public void Change_Shoots_Damage() => Server_Change_Damage();


    [Server]
    void Server_Change_Damage() => current_damage++;



    void Damage_Changed(int _old_damage, int _new_damage)
    {
        Upgrade_Projectiles_Damage_To_Everyone();
    }


    void Upgrade_Projectiles_Damage_To_Everyone()
    {
        List<GameObject> _shoots_list = shoots_pool.Get_Pool_Itens();

        foreach (GameObject bullets in _shoots_list)
        {
            bullets.GetComponent<Projectile>().Increase_Damage(1);
        }
    }
}
