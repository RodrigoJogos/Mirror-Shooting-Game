using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Respawn_Points : NetworkBehaviour
{
    private int choosen_number = -1;
    public List<Transform> spawn_points = new List<Transform>();



    [Server]
    public int Server_Choose_Spawn_Point()
    {
        choosen_number = Random.Range(0,spawn_points.Count);
        return choosen_number;
    }

}
