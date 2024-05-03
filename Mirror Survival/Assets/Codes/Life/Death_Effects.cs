using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Death_Effects : NetworkBehaviour
{
    private int choosen_index;

    [SerializeField] private Pool_GameObjects pool_reference;

    [SerializeField] private Transform space;

   

    public void Appear_Effects() => Get_Index_Pool();

   
    public void Get_Index_Pool()
    {
        // Get Index From Pool
        choosen_index = pool_reference.Get_Index_Obj_List();

        if (!pool_reference.Get_Specific_GameObject(choosen_index).activeSelf)
        {
            pool_reference.Server_Send_GameObject(choosen_index, space.position, Quaternion.identity);
        }
        else
        {
            Get_Index_Pool();
        }
    }

   
}
