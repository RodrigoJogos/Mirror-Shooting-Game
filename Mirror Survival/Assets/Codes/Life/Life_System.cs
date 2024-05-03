using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


public class Life_System : NetworkBehaviour
{
    [SyncVar(hook = nameof(All_Clients_Health_Changed))] int life = 10;

    private bool is_alive = true;

    [Header("Settings")]
    private string tag_name;
    [SerializeField] private float die_time;

    [Header("HUD")]
    [SerializeField] private TextMesh life_txt;
    [SerializeField] private PlayersLocal_Hud player_local_hud;


    [Header("Particles")]
    [SerializeField] private GameObject blood_effect;
    private Death_Effects death_effects;

    
    [Header("Body To Disable")]
    [SerializeField] private GameObject character_body;


    void Start()
    {
        tag_name = this.gameObject.tag;
        
        death_effects = GetComponent<Death_Effects>();
    }


    public void Lose_Health(int _amount ,Vector3 _received_pos)
    {
        if (isServer)
        {
            Server_ChangeLife(_amount);
        }

         blood_effect.SetActive(true);
         blood_effect.transform.position = _received_pos;
    }


    [Server]
    void Server_ChangeLife(int _amount)
    {
        life -= _amount;
    }

    void All_Clients_Health_Changed(int _oldlife, int _newlife)
    {
        life_txt.text = "" + life;
        Change_Health_Bar();

        if (life <= 0 && is_alive)
        {
            //character_body.SetActive(false);
            StartCoroutine(Die(die_time));
        }
    }

    void Change_Health_Bar()
    {
        if (player_local_hud != null && isLocalPlayer)
        {
            player_local_hud.Change_Health_Bar(life);
        }
    }

    public IEnumerator Die(float _seconds)
    {
        Set_Alive_State(false);
        this.gameObject.tag = "Untagged";
        yield return new WaitForSeconds(_seconds);

        if (death_effects != null)
        {
            death_effects.Appear_Effects();
            yield return new WaitForSeconds(0.15f);
        }
        
        this.gameObject.tag = tag_name;
        character_body.SetActive(false);
    }
  

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    
    public void Set_Alive_State(bool _next_value) 
    {
        is_alive = _next_value;
    } 
    public bool Get_Alive_State() 
    {
        return is_alive;
    } 


//////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // RESTORE HEALTH
    public void Reset_Life(int _new_life)
    {
        if (isServer) Server_Reset_Life(_new_life);
    }

    [Server]
    void Server_Reset_Life(int _new_life)
    {
        life = _new_life;
    }
  
}
