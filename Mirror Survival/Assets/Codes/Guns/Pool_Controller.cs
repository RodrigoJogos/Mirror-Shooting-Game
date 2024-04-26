using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class Pool_Controller : NetworkBehaviour
{
    // outside reference
    private Gun_Settings gun_settings;
    
    
    [Header("Pool Instance Prefab")]
    [SerializeField] private GameObject pool_prefab;


    //Shoots Pool References
    private int choosen_index;
    private Pool_GameObjects shoots_pool;


    void Start()
    {
        gun_settings = GetComponent<Gun_Settings>();

        if (isLocalPlayer)  Create_Pool_Player();
    }


    // Create Shoot Pool For this Player on the Server
    [Command]
    void Create_Pool_Player()
    {
        GameObject _pool_instance = Instantiate(pool_prefab, transform.position, transform.rotation);
        NetworkServer.Spawn(_pool_instance);

        shoots_pool = _pool_instance.GetComponent<Pool_GameObjects>();    
    }




    [Command]
    public void Cmd_Get_Index_Pool()
    {
        // Get Index From Pool
        choosen_index = shoots_pool.Get_Index_Obj_List();

        // Tell the Server Which Index Will be Choosen
        shoots_pool.Server_Send_GameObject(choosen_index, gun_settings.Origin_Shoot.position, gun_settings.Origin_Shoot.rotation);
    }



}
