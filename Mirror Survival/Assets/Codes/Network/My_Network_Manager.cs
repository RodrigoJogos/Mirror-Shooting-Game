using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//

//
public class My_Network_Manager : NetworkManager
{
    public TMP_InputField AddressField;

    public TMP_Text map_txt;

    public GameObject error_hud;

    [Space(30)]
    public int current_index = 0;
    public List<string> maps_names = new List<string>();

    
    void Start()
    {
        Select_Map(maps_names[current_index]);
    }


#region Create Room

    //Mexer nesse ainda!!!
    public void Set_Max_Players(int _amount)
    {
        NetworkManager.singleton.maxConnections = _amount;
    }
    /////////////////////////////////////////////////////////

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



    public void Join_Lobby()
    {
        NetworkManager.singleton.networkAddress = AddressField.text;

        NetworkManager.singleton.StartClient();
    }





     public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        //base.OnServerDisconnect(NetworkConnectionToClient conn);
        SceneManager.LoadScene("Error");

        //Quit_Room();
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();

        print("Cliente Conectou");
    }

    public override void OnClientDisconnect()
    {
        base.OnClientDisconnect();

        print("Cliente SAIU");

        if(error_hud != null) error_hud.SetActive(true);
        
    }

    


/////////////////////////////////////////////////////////////////////////////////////////////////////////////
///
    // Falta a Lógica de sair do jogo

    public void Quit_Room()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            NetworkManager.singleton.StopHost();
            print("Era host");    
        }
        else
        {
            NetworkManager.singleton.StopClient();
            print("Era cliente");    

        }

        SceneManager.LoadScene("Main Menu");
        Destroy(this.gameObject);
    }


    public void Quit_Game() =>  Application.Quit();


    
}
