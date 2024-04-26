using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Huds_Manager : MonoBehaviour
{    
    [Header("Texts")]
    [SerializeField] List<TMP_Text> game_texts = new List<TMP_Text>(); 

   
    [Header("Screens")]
    [SerializeField] List<GameObject> game_screens = new List<GameObject>(); 



    public void Set_Game_Screens(int _index_choosen, bool _next_state)
    {
        game_screens[_index_choosen].SetActive(_next_state);
    }


    public void Change_Choosen_Texts(int _index_choosen, string _next_text)
    {
        game_texts[_index_choosen].text = _next_text;
    }

}
