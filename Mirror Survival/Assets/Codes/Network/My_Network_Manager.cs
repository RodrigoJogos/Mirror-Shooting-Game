using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class My_Network_Manager : NetworkManager
{
    [Header("Create Room")]
    [SerializeField] private TMP_InputField AddressField;

    [Header("Error")]
    [SerializeField] private GameObject error_hud;

    
    [Header("Map")]
    [SerializeField] private TMP_Text map_txt;
    [SerializeField] private List<string> maps_names = new List<string>();
    private int current_index = 0;

    
    void Start() => Select_Map(maps_names[current_index]);


#region Create Room

    public void Set_Max_Players(int _amount)
    {
        NetworkManager.singleton.maxConnections = _amount;
    }


    public void Change_Map(int _amount)
    {
        current_index += _amount;

        if (current_index >= maps_names.Count)
        {
            current_index = 0;
        }

        if (current_index < 0)
        {
            current_index = maps_names.Count - 1;
        }

        Select_Map(maps_names[current_index]);
    }

    public void Select_Map(string _choosen_map)
    {
        map_txt.text = "" + _choosen_map;
        NetworkManager.singleton.onlineScene = _choosen_map;
    }


    public void Host_Lobby()
    {
        NetworkManager.singleton.StartHost();
    }

#endregion


#region JOIN

    public void Join_Lobby()
    {
        NetworkManager.singleton.networkAddress = AddressField.text;

        NetworkManager.singleton.StartClient();
    }

#endregion


#region DISCONNECTIONS

     public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        //base.OnServerDisconnect(NetworkConnectionToClient conn);
        //SceneManager.LoadScene("Error");
        //Quit_Room();
        // NetworkManager.singleton.StopClient();
        // SceneManager.LoadScene("Main Menu");
        // Destroy(this.gameObject);
    }

    public override void OnClientDisconnect()
    {
        base.OnClientDisconnect();

        if(error_hud != null) error_hud.SetActive(true);
    }

#endregion


#region QUIT

    public void Quit_Room()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopHost();
        }
        else
        {
            NetworkManager.singleton.StopClient();
        }

        SceneManager.LoadScene("Main Menu");
        Destroy(this.gameObject);
    }


    public void Quit_Game() =>  Application.Quit();

#endregion

}
