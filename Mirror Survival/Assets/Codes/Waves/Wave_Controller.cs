using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class Wave_Controller : NetworkBehaviour
{
    //Outside References
    private Pool_GameObjects enemies_pool;
    private Respawn_Points respawn_points;

    //Server Sync Variables
    [Header("Enemy Pool Index")]
    [SyncVar(hook = nameof(Server_GotEnemy_Index))] int index_enemy_choosen = -1;

    [Header("Spawn Point Index")]
    [SyncVar(hook = nameof(Changed_Spawn_Point))] int index_spawn_point = -1;



    void Start()
    {
        enemies_pool = GetComponentInChildren<Pool_GameObjects>();
        respawn_points = GetComponentInChildren<Respawn_Points>();
    }


    public void Create_Enemie_Process()
    {
        if (isServer) Get_Enemy_From_Pool();
    }

 

#region Enemy_Pool

    //SERVER GET FREE ENEMY GAME OBJECT INDEX FROM POOL
    [Server]
    public void Get_Enemy_From_Pool() => index_enemy_choosen = enemies_pool.Get_Index_Obj_List();



    public void Server_GotEnemy_Index(int _oldindex, int _newvindex)
    {
        if (index_enemy_choosen > -1)
        {
            if (isServer) index_spawn_point = respawn_points.Server_Choose_Spawn_Point();
        }
    }

#endregion



#region Respawn_Point

    // GOT A INDEX FROM SPAWN POSITIONS
    public void Changed_Spawn_Point(int _old_index, int _new_index)
    {   
        if (index_spawn_point > -1) Tell_Server_Create_Enemy();
    }

#endregion



#region Server_Create_Enemie
    public void Tell_Server_Create_Enemy()
    {
        if (isServer)
        {
            
            enemies_pool.Server_Send_GameObject (index_enemy_choosen, 
                                                 respawn_points.spawn_points[index_spawn_point].position, 
                                                 respawn_points.spawn_points[index_spawn_point].rotation 
                                                );
            
            Reset_Variables();
        }
    }


    // Reset Variables to avoid the numbers not changing its value
    [Server]
    void Reset_Variables()
    {
        index_enemy_choosen = -1;
        index_spawn_point = -1;
    }

#endregion


}
