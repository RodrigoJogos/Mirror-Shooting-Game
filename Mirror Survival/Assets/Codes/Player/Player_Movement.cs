using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player_Movement : NetworkBehaviour
{
    private Player_Inputs player_Inputs;
  
    private CharacterController charCon;

    
    [SerializeField] private float speed = 5f;
    public float Speed {get; set;}


    void Start()
    {
        if (!isLocalPlayer)
          {
               this.enabled = false;
          }
        
        charCon = GetComponent<CharacterController>();
        player_Inputs = GetComponentInParent<Player_Inputs>();
    }


    void Update()
    {
        if (isLocalPlayer) Move(player_Inputs.Set_Movement());
    }


    void Move(Vector3 _received_input)
    {
        _received_input.y = -1f;
        charCon.Move(_received_input * speed * Time.deltaTime);
    }
}
