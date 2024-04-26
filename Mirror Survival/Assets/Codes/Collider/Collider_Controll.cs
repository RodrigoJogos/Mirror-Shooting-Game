using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//

public class Collider_Controll : MonoBehaviour
{
    private int damage;

    public void Configure_New_Damage(int _new_damage)
    {
        damage = _new_damage;
    }

     void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou em contato possui uma tag específica
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Life_System>().Lose_Health(damage, transform.position);
        }
    }
}
