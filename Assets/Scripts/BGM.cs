using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().volume = GlobalOptions.bgmvolume;
    }
}
