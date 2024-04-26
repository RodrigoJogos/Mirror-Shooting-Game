using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;


public class Player_Nickname : NetworkBehaviour
{
    [SyncVar(hook = nameof(Send_Name_To_Manager))] public string nickname = null;

    [SerializeField] TextMesh name_txt;

    [SerializeField] GameObject ready_image;




    void Start()
    {
        if (isLocalPlayer)
        {
            string _name_test = PlayerPrefs.GetString("players_name");
            Cmd_Send_NickName(_name_test);
        }
    }

    public void Change_Rotation() => name_txt.GetComponent<Billboard>().enabled = true;


///////////////////////////////////////////////////////////////////////////////////////////////////


    [Command]
    void Cmd_Send_NickName(string _send_name) => Server_Change_NickName(_send_name);

    [Server]
    void Server_Change_NickName(string _send_name) => nickname = _send_name;


    void Send_Name_To_Manager(string _old_name, string _new_name)
    {
        Names_Manager names_manager = GameObject.Find("Players Manager").GetComponent<Names_Manager>();
        names_manager.Add_NickName(this);
    }

  

///////////////////////////////////////////////////////////////////////////////////////////////////
///
    public void Update_NickNames(string _nick)
    {
        name_txt.text = "" + _nick;
    }

 

    void OnDisable()
    {
        name_txt.gameObject.SetActive(false);

        if (isLocalPlayer) Cmd_Disable_ReadyImage_In_Server();
    } 

    [Command]
    void Cmd_Disable_ReadyImage_In_Server() => Disable_ReadyImage_To_All_Clients();


    [ClientRpc]
    void Disable_ReadyImage_To_All_Clients()
    {
        ready_image.SetActive(false);
        Change_Rotation();
    }
}
