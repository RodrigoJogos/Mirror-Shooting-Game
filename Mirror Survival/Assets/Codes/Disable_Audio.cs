using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable_Audio : MonoBehaviour
{
    public AudioListener camera_audio;

    // Start is called before the first frame update
    void Start()
    {
        camera_audio = GetComponent<AudioListener>();

        Destroy(camera_audio);
    }

    
}
