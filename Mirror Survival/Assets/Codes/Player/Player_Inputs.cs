using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_Inputs : NetworkBehaviour
{
    private Vector3 movement;

    private Vector3 mouse_position;
   
    private bool is_shooting, is_reloading, has_aimed;




    void Start()
    {
       if (!isLocalPlayer)
          {
               this.enabled = false;
          }
    }


    public Vector3 Set_Movement()
    {
        movement =  new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
        return movement;
    }

    public Vector3 Set_Mouse_Position()
    {
        mouse_position = Input.mousePosition;
        mouse_position = Camera.main.ScreenToWorldPoint(new Vector3(mouse_position.x, mouse_position.y, Camera.main.transform.position.y - transform.position.y));
        return mouse_position;        
    }

    
    public bool Set_LeftClick()
    {
        is_shooting = Input.GetButton("Primary Fire");
        return is_shooting;
    }
        
    
    public bool Set_Reload()
    {
        is_reloading = Input.GetButtonDown("Reload");
        return is_reloading;
    }

     public bool Set_RightClick()
    {
        has_aimed = Input.GetButtonDown("Aim");
        return has_aimed;
    }

   
}
