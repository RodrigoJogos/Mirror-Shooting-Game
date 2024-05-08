using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class Player_Rotation : NetworkBehaviour
{
    private Player_Inputs player_Inputs;


    [SerializeField]
    private float turn_speed = 22f; 


    void Start() 
    {
        if (!isLocalPlayer)
          {
               this.enabled = false;
          }
        
        player_Inputs = GetComponentInParent<Player_Inputs>();
    } 


    void Update()
    {
        if (isLocalPlayer) Look_Aim(player_Inputs.Set_Mouse_Position());
    }


    void Look_Aim(Vector3 _target_position)
    {
        Vector3 _target_direction = _target_position - transform.position;
        _target_direction.y = 0;

        Quaternion _target_rotation = Quaternion.LookRotation(_target_direction);
        
        transform.rotation = Quaternion.Lerp(transform.rotation, _target_rotation, turn_speed * Time.deltaTime);
    }

}
