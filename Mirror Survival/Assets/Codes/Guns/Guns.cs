using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Guns 
{
    public string name = "Default";

    public bool is_reloading;

    public float next_fire_time, fireRate, reload_time;

    public int ammo, original_ammo, damage;
    
    public AnimationClip shooting_clip, reloading_clip;

    public Sprite icon_hud;


    public Guns(Gun_Data _gun_data)
    {
        name = _gun_data.name;
        is_reloading = _gun_data.is_reloading;
        next_fire_time = _gun_data.next_fire_time;
        fireRate = _gun_data.fireRate;
        ammo = _gun_data.ammo;
        original_ammo = _gun_data.original_ammo;
        damage = _gun_data.damage;
        reload_time = _gun_data.reload_time;
        shooting_clip = _gun_data.shooting_clip;
        reloading_clip = _gun_data.reloading_clip;

        icon_hud = _gun_data.icon_hud;
    }

    
}
