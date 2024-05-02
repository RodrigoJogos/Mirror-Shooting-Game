using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_Sounds : NetworkBehaviour
{
    [Header("Pistol")]    
    public AudioListener player_listener;

    public List<AudioSource> gun_sounds = new List<AudioSource>();

    public GameObject muzzle_flash;

    
    void Start()
    {
        player_listener = GetComponentInParent<AudioListener>();
        
        if (!isLocalPlayer) Destroy(player_listener);
    }

    public void Pistol_Reloading_Sound()
    {
        if (isLocalPlayer) Cmd_SendAudio(0);
    }


    public void Pistol_Shoot_Sound()
    {
        if (isLocalPlayer)
        {
            Cmd_Muzzle_Change(true);
            Cmd_SendAudio(1);
        }
    }

    public void Stop_Pistol_Shoot_Sound() => Cmd_Muzzle_Change(false);
  





    [Command]
    public void Cmd_Muzzle_Change(bool _state) => Received_Muzzle_Changed(_state);

    [ClientRpc]
    public void Received_Muzzle_Changed(bool _state) => muzzle_flash.SetActive(_state);





    [Command]
    public void Cmd_SendAudio(int _choosen_index) =>  Received_Audio(_choosen_index);

    [ClientRpc]
    public void Received_Audio(int _choosen_index)
    {
        gun_sounds[_choosen_index].Stop();
        gun_sounds[_choosen_index].Play();
    }

}
