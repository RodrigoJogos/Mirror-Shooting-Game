using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;


public class Game_Manager : NetworkBehaviour
{
    //Outside References
    private Wave_Controller wave_controller;
    private Huds_Manager huds_manager;


    [Header("Current Wave")]
    public Wave_Class wave_class;


    [Header("Level Waves")]
    [SerializeField] private List<Wave_Data> waves = new List<Wave_Data>(); 
    [SyncVar(hook = nameof(Server_Count_Changed))] int waves_survived = 0;
    private int current_wave = -1;


    void Start()
    {
        wave_controller = GetComponentInChildren<Wave_Controller>();
        huds_manager = GameObject.Find("Canvas Game").GetComponent<Huds_Manager>();
    } 



#region Wave_Working_Flow

    public IEnumerator Countdown_Next_Wave(string _text_info ,float _timer)
    {
        while (_timer >= 0)
        {
            yield return new WaitForSeconds(1f);
            huds_manager.Change_Choosen_Texts(0,"" + _text_info + _timer);
            _timer--;
        }
        
        Start_New_Wave();
    }

    public void Start_New_Wave()
    {
        current_wave++;
        wave_class = null;
        wave_class = new Wave_Class(waves[current_wave]);

        huds_manager.Change_Choosen_Texts(0,"" + wave_class.name);
        huds_manager.Change_Choosen_Texts(1, wave_class.limit_wave + " Enemies Left");

        Game_Events.singleton.Change_Game_Event("Disable_Player_Upgrades");

        Continue_Wave();
    }

    public void Continue_Wave() => StartCoroutine(Wave_Enemies_Process());


    IEnumerator Wave_Enemies_Process()
    {
        yield return new WaitForSeconds(wave_class.wait_timer);

        // Verify if already spawned all enemies from this wave
        if (wave_class.enemies_spawned < wave_class.limit_wave)
        {
            wave_controller.Create_Enemie_Process();
            Continue_Wave();
        }
        
    }

#endregion


#region Increase_Kills_Finish_Wave_System

    public void Increase_Kills()
    {
        wave_class.enemys_killed++;
        
        huds_manager.Change_Choosen_Texts(1, (wave_class.limit_wave - wave_class.enemys_killed) + " Enemies Left");

        if (wave_class.enemys_killed >= wave_class.limit_wave)
        {
            if (isServer) Server_Count_Increase();

            return;
        }

        Continue_Wave();
    }
   

    [Server]
    void Server_Count_Increase() => waves_survived++;

    void Server_Count_Changed(int _oldnum, int _newnum)
    {
        if (waves_survived < waves.Count)
        {
            huds_manager.Change_Choosen_Texts(0,"Wave Ended");
            huds_manager.Change_Choosen_Texts(1, waves_survived + " Waves Survived");

            Game_Events.singleton.Change_Game_Event("Wave_Finished");
            return;
        }
        
        huds_manager.Change_Choosen_Texts(0,"Game WON");
        huds_manager.Change_Choosen_Texts(1, waves_survived + " Waves Survived");
        Game_Events.singleton.Change_Game_Event("Game_Won");
    }

#endregion


    public Wave_Data Get_Data_From_CurrentWave()
    {
        return waves[current_wave];
    }

}
