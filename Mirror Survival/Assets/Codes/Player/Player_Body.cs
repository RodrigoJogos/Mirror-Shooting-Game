using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_Body : NetworkBehaviour
{
    void OnDisable() => Game_Events.singleton.Change_Game_Event("Player_Died");

}
