using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_Join : NetworkBehaviour
{
    private Start_Game start_system;

    private Transform the_player;

    [SerializeField] private Transform ready_image;


    void Start()
    {
        start_system = GameObject.Find("Players Manager").GetComponent<Start_Game>();

        the_player = transform.GetChild(0);
    }


    public void Set_Player_Ready()
    {
        start_system.Get_Local_Player(the_player);

        if (isLocalPlayer) Cmd_Confirm_Ready();
    }


    [Command]
    public void Cmd_Confirm_Ready()
    {
        start_system.Server_Set_Ready_Player();
        ReceivedConfirm_Ready(true);
    }


    [ClientRpc]
    public void ReceivedConfirm_Ready(bool _state)
    {
        ready_image.GetChild(0).gameObject.SetActive(_state);
        ready_image.gameObject.SetActive(_state);
    }

    
}
