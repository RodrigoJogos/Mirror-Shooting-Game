using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_Skin : NetworkBehaviour
{
    [SyncVar(hook = nameof(Send_Info_To_Manager))] public int skin_choosen = -1;

    [Header("Head Part")]
    [SerializeField] List<GameObject> heads = new List<GameObject>();

    [Header("Body Part")]
    [SerializeField] List<GameObject> bodys = new List<GameObject>();

    [Header("HUD Icon")]
    [SerializeField] PlayersLocal_Hud playerLocal_Hud;
    [SerializeField] List<Sprite> icons = new List<Sprite>();


    void Start()
    {
        //Disable all Character Skins and Body Parts
        for (int i = 0; i < 2; i++)
        {
            heads[i].SetActive(false);
            bodys[i].SetActive(false);
        }

        if (isLocalPlayer)
        {
            int _index_skin = PlayerPrefs.GetInt("skin_number");
            Cmd_Send_Skin(_index_skin);

            playerLocal_Hud.Set_Character_Icon(icons[_index_skin]);
        }
    }


///////////////////////////////////////////////////////////////////////////////////////////////////


    [Command]
    void Cmd_Send_Skin(int _skin_value) => Server_Change_Skin(_skin_value);

    [Server]
    void Server_Change_Skin(int _skin_value) => skin_choosen = _skin_value;


    void Send_Info_To_Manager(int _old_skin, int _new_skin)
    {
        Skins_Manager skins_Manager = GameObject.Find("Players Manager").GetComponent<Skins_Manager>();
        skins_Manager.Add_Skin_To_Manager(this);
    }

  

///////////////////////////////////////////////////////////////////////////////////////////////////


    public void Update_Character_Skins(int _index_skin)
    {
        heads[_index_skin].SetActive(true);
        bodys[_index_skin].SetActive(true);
    }

    
}
