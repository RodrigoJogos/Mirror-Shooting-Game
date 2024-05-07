using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class Game_Events : NetworkBehaviour
{
    //Singleton Settings
    public static Game_Events singleton;
    void Awake() => singleton = this;

    //Outside References
    private Game_Manager game_manager;
    private Players_Manager players_controller;
    private Huds_Manager huds_manager;
    private Start_Game start_game;
    

    // Events
    private string case_choosen = "default";
    bool allowed = true;


    void Start()
    {
        players_controller = GetComponentInChildren<Players_Manager>();
        start_game = GetComponentInChildren<Start_Game>();

        game_manager = GetComponent<Game_Manager>();
        huds_manager = GameObject.Find("Canvas Game").GetComponent<Huds_Manager>();
    }
    

    public void Change_Game_Event(string _new_event)
    {
        if (allowed)
        {
            case_choosen = _new_event;
            Switch_Event();
        } 
    }


    void Switch_Event()
    {
        switch (case_choosen)
        {
            case "Created_Enemie":
                game_manager.wave_class.enemies_spawned++;
                break;

            case "Enemie_Dies":
                game_manager.Increase_Kills();
                break;

            case "Wave_Finished":
                if (players_controller != null)
                {
                    players_controller.Revive_All_Players(true);
                    game_manager.StartCoroutine(game_manager.Countdown_Next_Wave("Next Wave ",10f));

                    start_game.Access_Player_Controllers(false);
                }
                break;

            case "Player_Died":
                players_controller.Increase_Dies();
                break;

            case "Game_Over":
                StartCoroutine(Disable_All_Childs(0f, 0, true));
                allowed = false;
                break;

            case "Game_Starts":
                game_manager.StartCoroutine(game_manager.Countdown_Next_Wave("",0f));
                break;

            case "Game_Won":
                StartCoroutine(Disable_All_Childs(3f, 1, true));
                allowed = false;
                break;

            case "Disable_Player_Upgrades":
                start_game.Access_Player_Controllers(true);
                break;

            default:
                Debug.Log("No Event");
                break;
        }
    }




    IEnumerator Disable_All_Childs(float _time_choosen, int _choosen_index, bool _next_state)
    {
        yield return new WaitForSeconds(1f);
        Destroy(transform.GetChild(1).gameObject);

        yield return new WaitForSeconds(_time_choosen);
        huds_manager.Set_Game_Screens(_choosen_index , _next_state);
       
        yield return new WaitForSeconds(2f);
        players_controller.Revive_All_Players(false);
        players_controller = null;
    }


}
