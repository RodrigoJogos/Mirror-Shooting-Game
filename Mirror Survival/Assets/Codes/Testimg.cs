using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testimg : MonoBehaviour
{
    public Transform target,target2;


    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;

        transform.rotation = target.rotation;
    }
}
