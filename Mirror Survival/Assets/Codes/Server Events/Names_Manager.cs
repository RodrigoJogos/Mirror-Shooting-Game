using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Names_Manager : MonoBehaviour
{
    [SerializeField]
    List<Player_Nickname> all_players_nicknames = new List<Player_Nickname>();


    public void Add_NickName(Player_Nickname _names)
    {
        all_players_nicknames.Add(_names);

        foreach (Player_Nickname _players in all_players_nicknames)
        {
            _players.Update_NickNames(_players.nickname);
        }
    }

}
