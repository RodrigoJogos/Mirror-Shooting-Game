using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Aim : MonoBehaviour
{
    private LineRenderer laser;

    [Header("Origin")]
    [SerializeField] private Transform pointA;

    [Header("Default Destination")]
    [SerializeField] private Transform pointB;

    [Header("Length")]
    [SerializeField] private float max_length = 5f;


    void Start() => laser = GetComponent<LineRenderer>();


    void Update()
    {
            RaycastHit hit;

            if (Physics.Raycast(pointA.position, transform.forward, out hit, max_length))
            {
                Vector3 pontoDeColisao = hit.point;
                Draw_Aim_Line(pontoDeColisao);
            }
            else
            {               
                 Draw_Aim_Line(pointB.position);
            }
        
    }

    public void Draw_Aim_Line(Vector3 _target)
    {
        laser.SetPosition(0,pointA.position);
        laser.SetPosition(1,_target);
    }


    public void Set_Laser_State()
    {
        if (!this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(true);
            return;
        }

        if (this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
            return;
        }     
    }

}
