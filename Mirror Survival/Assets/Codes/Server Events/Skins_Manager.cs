using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skins_Manager : MonoBehaviour
{
    [SerializeField]
    List<Player_Skin> all_players_skins = new List<Player_Skin>();


    public void Add_Skin_To_Manager(Player_Skin _player_skin)
    {
        all_players_skins.Add(_player_skin);

        foreach (Player_Skin _players in all_players_skins)
        {
            _players.Update_Character_Skins(_players.skin_choosen);
        }
    }


}
