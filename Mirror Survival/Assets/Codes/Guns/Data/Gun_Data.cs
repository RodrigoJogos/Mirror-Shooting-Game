using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Gun Data")]
public class Gun_Data : ScriptableObject
{

    [Header("Gun Information")]

    public string name = "Default";

    public bool is_reloading;

    public float next_fire_time, fireRate, reload_time;

    public int ammo, original_ammo, damage;
    
    public AnimationClip shooting_clip, reloading_clip;

    public Sprite icon_hud;

    
}
