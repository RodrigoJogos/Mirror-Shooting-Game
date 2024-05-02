using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;


public class Start_Game : NetworkBehaviour
{
    private Players_Manager players_Manager;
    [SyncVar(hook = nameof(Player_Ready_Count_Changed))] public int ready_players_count = 0;

    [Space(30)]

    [SyncVar(hook = nameof(Changed_MaxPlayers_Room))] public int max_players_room = 0;

    [Space(30)]

    [SerializeField] private Transform my_player;

    [Space(30)]
    [SerializeField] private GameObject fade_HUD;
    [SerializeField] private GameObject enemies_HUD;
    [SerializeField] private TMP_Text countdown_txt;


    void Start()
    {
        players_Manager = GetComponent<Players_Manager>();
        
        Load_MaxPlayers_Room();
    }


    [Server]
    public void Server_Set_Ready_Player() => ready_players_count++;


    public void Player_Ready_Count_Changed(int _oldcount, int _newcount)
    {
        if (ready_players_count >= max_players_room) // change this after
        {
            StartCoroutine(Counting_Start_Game());
        }
    }


    public void Get_Local_Player(Transform _received_player)
    {
        my_player = _received_player;
    }


    IEnumerator Counting_Start_Game()
    {
        for (int i = 4; i > 0; i--)
        {
            countdown_txt.text = "" + i;
            yield return new WaitForSeconds(1f);
        }

        fade_HUD.SetActive(true);
        yield return new WaitForSeconds(2f);
        
        // Unlock Player Controlls
        enemies_HUD.SetActive(true);
        my_player.GetComponentInParent<Player_Block>().Appear_Player_Hud();
        Access_Player_Controllers(true);


        players_Manager.Find_All_Players_In_Game();
        Game_Events.singleton.Change_Game_Event("Game_Starts");
    }

    
    public void Access_Player_Controllers(bool _state)
    {
        my_player.GetComponentInParent<Player_Block>().Control_Player(_state);
    }



    //////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    public void Load_MaxPlayers_Room()
    {
        if (PlayerPrefs.HasKey("Max_Players_Room"))
        {
              
            if (isServer)
            {
                Server_Set_MaxPlayers(PlayerPrefs.GetInt("Max_Players_Room"));
            }
        }
    }

    [Server]
    public void Server_Set_MaxPlayers(int _choosen_number)
    {
        max_players_room = _choosen_number;
    }


    public void Changed_MaxPlayers_Room(int _oldcount, int _newcount)
    {
       
    }

}
