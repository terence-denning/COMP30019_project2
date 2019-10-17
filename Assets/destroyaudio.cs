using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyaudio : MonoBehaviour
{
    private void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
}
