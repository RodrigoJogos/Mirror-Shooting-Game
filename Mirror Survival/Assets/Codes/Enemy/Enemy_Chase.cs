using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class Enemy_Chase : NetworkBehaviour
{
    [SerializeField] private Players_Manager players_manager;

    //Sync Target Index
    [SyncVar(hook = nameof(Gotcha_Target))] int player_choosen = -1;


    //Outside References
    private NavMeshAgent navMeshAgent;
    private Transform my_target; //trocar private depois de testar


    //Avoid Calling same function twice
    private bool already_have_target; 
    private float distance;

   
    void Awake() => navMeshAgent = GetComponent<NavMeshAgent>();


 

#region Choosing_Target_Mechanic

    public void Request_Server_Target()
    {
        if (isServer)
        {
            ResetVariable();
            player_choosen = players_manager.Server_Draft_Number();
        }
    }

    [Server]
    void ResetVariable() => player_choosen = 9;


    void Gotcha_Target(int _oldcount, int _newcount)
    {  
        if (player_choosen == 9)  return;
    
        my_target = players_manager.Get_Player_Transform(player_choosen);


        // If the target choosen is not active, choose another one
        if (!my_target.gameObject.activeSelf)
        {
            Target_Not_Available();
        } 
    }


    void Target_Not_Available()
    {
        already_have_target = false;

        //In case the target is not active, choose another one
        if (!already_have_target)
            {
                already_have_target = true;
                Request_Server_Target();
            }
    }


#endregion



    public void Chase_Target()
    {
       if (my_target != null)
       {
            if (my_target.gameObject.activeSelf)
            {
                navMeshAgent.SetDestination(my_target.position);
                return;
            }

            Target_Not_Available();
       }
    }
    


    public float Get_Distance_From_Target()
    {
        if (my_target != null)
        {
            distance = Vector3.Distance(my_target.position, transform.position);
        }

        return distance;
    }
   


    //TESTING ANIMATIONS
    public void EnableNavMesh()
    {
        navMeshAgent.enabled = true;
    }
    public void DisableNavMesh()
    {
        navMeshAgent.enabled = false;
    }
}
