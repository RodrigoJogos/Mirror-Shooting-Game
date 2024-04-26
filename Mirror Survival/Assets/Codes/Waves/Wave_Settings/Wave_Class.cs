using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  //CLASS
[System.Serializable]
public class Wave_Class
{
    public string name;
    public float wait_timer;
    public int limit_wave, enemies_spawned, enemys_killed;
    
   
    public Wave_Class(Wave_Data _wave_data)
    {
        name = _wave_data.name;

        wait_timer = _wave_data.wait_timer;

        wait_timer = _wave_data.wait_timer;
        limit_wave = _wave_data.limit_wave;
        enemies_spawned = _wave_data.enemies_spawned;
        enemys_killed = _wave_data.enemys_killed;
    }


}
