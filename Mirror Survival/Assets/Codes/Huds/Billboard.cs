using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Vector3 choosen_rotation;


    void Update()
    {
        transform.rotation = Quaternion.Euler(choosen_rotation);
    }

    
}
