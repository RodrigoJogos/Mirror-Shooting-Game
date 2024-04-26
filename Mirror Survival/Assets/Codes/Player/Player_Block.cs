using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player_Block : MonoBehaviour
{
     private Player_Movement player_movement;
     private Camera_Follow camera_follow;
     private Player_Rotation player_rotation;
     private Player_Animations player_animations; 
     private Player_Gun player_gun;
     private Gun_Settings gun_settings;
     private Player_Nickname player_nickname;


     [SerializeField] private GameObject player_Hud;
     


     void Start()
     {
          player_movement = GetComponentInChildren<Player_Movement>();
          camera_follow = GetComponentInChildren<Camera_Follow>();
          player_rotation = GetComponentInChildren<Player_Rotation>();
          player_animations = GetComponentInChildren<Player_Animations>();
          player_gun = GetComponentInChildren<Player_Gun>();
          gun_settings = GetComponentInChildren<Gun_Settings>();
          player_nickname = GetComponentInChildren<Player_Nickname>();
     }


     public void Appear_Player_Hud() => player_Hud.SetActive(true);



     public void Control_Player(bool _is_allowed)
     {
          player_movement.enabled = _is_allowed;
          camera_follow.enabled = _is_allowed;
          player_rotation.enabled = _is_allowed;
          player_animations.enabled = _is_allowed;
          player_gun.enabled = _is_allowed;
          gun_settings.enabled = _is_allowed;

          player_nickname.Change_Rotation();
          player_nickname.enabled = !_is_allowed;         
     }
   
}
