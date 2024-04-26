using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Projectile : NetworkBehaviour
{
    [Header("Physics")]
    [SerializeField] Rigidbody rb;


    [Header("Settings")]
    [SerializeField] int damage;
    [SerializeField] float speed, destroy_time;





    void OnEnable() => StartCoroutine(Voltar_Piscina());


    // Update is called once per frame
    void Update() => rb.velocity = transform.forward * speed;    
    

    void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou em contato possui uma tag específica
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Life_System>().Lose_Health(damage, transform.position);
            this.gameObject.SetActive(false);
        }
    }
   

    IEnumerator Voltar_Piscina()
    {
        yield return new WaitForSeconds(destroy_time);
        this.gameObject.SetActive(false);
    }

    void OnDisable()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    } 



    public void Increase_Damage(int _amount)
    {
        damage += _amount;
    }
}
