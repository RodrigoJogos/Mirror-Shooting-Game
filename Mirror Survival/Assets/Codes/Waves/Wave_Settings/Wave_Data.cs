using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DATA
[CreateAssetMenu(fileName = "Wave Rules")]
public class Wave_Data : ScriptableObject
{
    [Header("Wave Settings")]

    public string name = "Default";
    public float wait_timer;
    public int limit_wave, enemies_spawned, enemys_killed;


    [Header("Enemy Status Settings")]
    public float speed;
    public int life,damage;

}







