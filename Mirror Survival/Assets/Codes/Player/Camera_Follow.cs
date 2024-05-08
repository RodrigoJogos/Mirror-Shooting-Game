using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Camera_Follow : NetworkBehaviour
{
    private Camera player_camera;

    [Header("Camera Settings")]    
    [SerializeField] private Vector3 cam_angle_adjust; 


    // Start is called before the first frame update
    void Start()
    {
        if(isLocalPlayer)
        {
            player_camera = Camera.main;
            player_camera.transform.rotation = Quaternion.Euler(50f,0f,0f);
            return;
        }

        this.enabled = false;
    }

    void LateUpdate()
    {
        if(isLocalPlayer) player_camera.transform.position = this.transform.position + cam_angle_adjust;
    }
             
}
