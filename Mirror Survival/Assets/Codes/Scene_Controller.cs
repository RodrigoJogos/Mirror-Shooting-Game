using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene_Controller : MonoBehaviour
{
    public void Load_Level(string _choosen_level)
    {
        SceneManager.LoadScene(_choosen_level);
    }


    public void Quit_Online()
    {
        My_Network_Manager my_Network_Manager = GameObject.Find("Network Manager").GetComponent<My_Network_Manager>();

        my_Network_Manager.Quit_Room();
    }

    
}
