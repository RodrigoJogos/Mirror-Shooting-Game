using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Pool_GameObjects : NetworkBehaviour
{
    [SerializeField]
    private List<GameObject> itens_list = new List<GameObject>();


    public int Get_Index_Obj_List()
    {
        for (int _index = 0; _index < itens_list.Count; _index++)
        {
            if (!itens_list[_index].activeSelf)
            {
                return _index;
            }
        }
        return -1;
    }


    // Tell the Server Which Index Will be Choosen
    [Server]
    public void Server_Send_GameObject (int _choosen_index, Vector3 _pos, Quaternion _rot)
    {
        Clients_Recieved_GameObject(_choosen_index, _pos, _rot);
    }


    // Activate The Game Object To All Clients
    [ClientRpc]
    public void Clients_Recieved_GameObject(int _choosen_index, Vector3 _pos, Quaternion _rot)
    {
        itens_list[_choosen_index].transform.position = _pos;
        itens_list[_choosen_index].transform.rotation = _rot;
        itens_list[_choosen_index].SetActive(true);
    }


    public List<GameObject> Get_Pool_Itens()
    {
        return itens_list;
    }

    public GameObject Get_Specific_GameObject(int _index)
    {
        return itens_list[_index];
    }
  
}
