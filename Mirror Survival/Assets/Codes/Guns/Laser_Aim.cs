using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Aim : MonoBehaviour
{
    public LineRenderer laser;

    public Transform pointA, pointB;

    public  float comprimentoMaximo = 10f;

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

}
