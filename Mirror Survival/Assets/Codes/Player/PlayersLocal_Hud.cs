using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayersLocal_Hud : MonoBehaviour
{
    [SerializeField] GameObject hud_controller = null; 

    [Header("Basic Info")]
    [SerializeField] TMP_Text name_txt = null; 
    [SerializeField] Image char_icon = null;
    [SerializeField] private Slider health_bar = null;

    [Header("Ammo Info")]
    [SerializeField] Image gun_image = null;
    [SerializeField] TMP_Text ammo_txt = null; 


    [Header("Upgrades")]
    [SerializeField] GameObject upgrades_screen = null;
    //[SerializeField] TMP_Text ammo_txt = null; 



    void Start()
    {
        Set_Name();
    }

    void Set_Name()
    {
        string _nickname = PlayerPrefs.GetString("players_name");
        name_txt.text = _nickname;
    }

    public void Set_Character_Icon(Sprite _icon)
    {
        char_icon.sprite = _icon;
    } 


    public void Define_State(bool _next_state) => hud_controller.SetActive(_next_state);


    public void Set_Gun(Sprite _icon_gun, int _ammo)
    {
        gun_image.sprite = _icon_gun;
        ammo_txt.text = "" + _ammo;
    }

    public void Set_Ammo(int _new_ammo) => ammo_txt.text = "" + _new_ammo;

    public void Change_Health_Bar(int _new_value) => health_bar.value = _new_value;

    public void Open_Upgrades_HUD() => upgrades_screen.SetActive(true);



}
