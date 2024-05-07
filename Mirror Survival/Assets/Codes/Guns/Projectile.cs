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


    IEnumerator Voltar_Piscina()
    {
        yield return new WaitForSeconds(destroy_time);
        this.gameObject.SetActive(false);
    }


    void Update() => rb.velocity = transform.forward * speed;    



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Life_System>().Lose_Health(damage, transform.position);
            this.gameObject.SetActive(false);
        }

        if (other.CompareTag("Environment"))
        {
            this.gameObject.SetActive(false);
        }
    }
   


    void OnDisable()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    } 


    public void Increase_Damage(int _amount) =>  damage += _amount;
}
