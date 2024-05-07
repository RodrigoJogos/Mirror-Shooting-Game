using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;


public class Enemy_Status : NetworkBehaviour
{   
    [Header("Outside References")]
    private Game_Manager game_manager;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Life_System enemy_life;
    [SerializeField] private Collider_Controll enemy_attack;
    

    [Header("Enemy Class")]
    public Status my_status = new Status("Zombie",0f,0,0,0);
    private Wave_Data wave_data;


    void Awake()
    {   
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
        game_manager =  Game_Events.singleton.gameObject.GetComponent<Game_Manager>();
    }


    void OnEnable() => Load_My_Status();



    void Load_My_Status()
    {
        wave_data = game_manager.Get_Data_From_CurrentWave();

        my_status.speed = wave_data.speed;
        my_status.max_life = wave_data.life;
        my_status.current_life = wave_data.life;
        my_status.damage = wave_data.damage;

        Change_Status();
    }

    void Change_Status()
    {
        navMeshAgent.speed = my_status.speed;
        enemy_life.Reset_Life(my_status.current_life);
        enemy_attack.Configure_New_Damage(my_status.damage);
    }


}
