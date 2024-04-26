using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Players_Manager : NetworkBehaviour
{
    private int _player_number;
    
    private int players_dies = 0;

    [SerializeField]
    private List<GameObject> server_players = new List<GameObject>();



    public void Find_All_Players_In_Game()
    {
        server_players.Clear();
        
        GameObject[] _found_players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject _players in _found_players)
        {
            server_players.Add(_players);
        }
    }


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///

    [Server]
    public int Server_Draft_Number()
    {
        _player_number = Random.Range( 0, server_players.Count );
        return _player_number;
    }

    public Transform Get_Player_Transform(int _choosen_index)
    {
        return server_players[_choosen_index].transform;
    }


////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///

     public void Increase_Dies()
    {
        players_dies++;
        
        if (players_dies >= 2) //Mudar esse valor depois
        {
            Game_Events.singleton.Change_Game_Event("Game_Over");
        }
    }

    
    public void Revive_All_Players(bool _next_state)
    {
        foreach (GameObject _players in server_players)
        {
            players_dies = 0;
            _players.GetComponent<Life_System>().Reset_Life(10);
            _players.SetActive(_next_state);
            //open upgrades available
            
        }
    }


   
}
