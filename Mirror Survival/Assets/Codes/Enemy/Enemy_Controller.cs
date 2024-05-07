using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Enemy_Controller : NetworkBehaviour
{
    private Enemy_Chase enemy_chase;
    private Enemy_Animation enemy_animation;
    private Life_System life_system;
   
   
    void Awake()
    {
        enemy_chase = GetComponent<Enemy_Chase>();
        enemy_animation = GetComponent<Enemy_Animation>();
        life_system = GetComponentInChildren<Life_System>();
    }


    void OnEnable()
    {
        Game_Events.singleton.Change_Game_Event("Created_Enemie");

        enemy_chase.Request_Server_Target();

        enemy_chase.EnableNavMesh();

        life_system.Set_Alive_State(true);
    }


    void Update()
    {
        enemy_animation.Die_Animation(life_system.Get_Alive_State());

        if (life_system.Get_Alive_State())
        {
            enemy_chase.Chase_Target();

            enemy_animation.Run_Attack_Animation(enemy_chase.Get_Distance_From_Target());
        }        
    }


    void OnDisable() => Game_Events.singleton.Change_Game_Event("Enemie_Dies");

}
