using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Aim : MonoBehaviour
{
    private LineRenderer laser;

    [SerializeField] private Transform pointA, pointB;

    [SerializeField] private float comprimentoMaximo = 10f;


    // Start is called before the first frame update
    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
            // Cria um Raycasthit para armazenar as informações do que foi atingido
            RaycastHit hit;

            // Lança um raio na direção definida
            if (Physics.Raycast(pointA.position, transform.forward, out hit, comprimentoMaximo))
            {
                // Se o raio atingiu algo
                Vector3 pontoDeColisao = hit.point;
                Draw_Aim_Line(pontoDeColisao);

            }
            else
            {
                // Se o raio não atingiu nada
               
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
