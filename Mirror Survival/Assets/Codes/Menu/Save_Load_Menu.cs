using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//teste
using UnityEngine.SceneManagement;

public class Save_Load_Menu : MonoBehaviour
{
   
    [Header("Menu Screen")]
    [SerializeField] GameObject introduction_screen;


    [Header("Name Settings")]
    private string player_name;
    [SerializeField] TMP_InputField input_type_name;
    [SerializeField] GameObject name_screen;


    [Header("Skins Settings")]
    private int skin_choosen;
    [SerializeField] GameObject[] select_buttons;
    [SerializeField] GameObject[] select_toggles;


    void Start() => Load_Player_Name();


    public void Save_Player_Name()
    {
        player_name = input_type_name.text;
        PlayerPrefs.SetString("players_name", player_name);
    }

    public void Load_Player_Name()
    {
        if (PlayerPrefs.HasKey("players_name"))
        {
            player_name = PlayerPrefs.GetString("players_name");  
            name_screen.SetActive(false);
            introduction_screen.SetActive(true);
        }
    }

/////////////////////////////////////////////////////////////////////////////////

    public void Save_Skins(int _choosen_number)
    {
        skin_choosen = _choosen_number;
        PlayerPrefs.SetInt("skin_number", skin_choosen);
    }

    public void Load_Skins()
    {
        if (PlayerPrefs.HasKey("skin_number"))
        {
            skin_choosen = PlayerPrefs.GetInt("skin_number");

            for (int i = 0; i < 2; i++)
            {
                select_buttons[i].SetActive(true);
                select_toggles[i].SetActive(false);
            }
            select_buttons[skin_choosen].SetActive(false);
            select_toggles[skin_choosen].SetActive(true);
        }
    }


    public void Quit_Game() =>  Application.Quit();



// APAGAR DEPOIS CODIGO A SEGUIR
    public void Load_Scene(string _name_scene)
    {
        SceneManager.LoadScene(_name_scene);
    }


}
