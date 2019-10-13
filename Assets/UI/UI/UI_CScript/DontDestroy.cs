using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    

    int sizeofobjs;
    int sizeofcameras;

    

    void Awake(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
        GameObject[] cameras = GameObject.FindGameObjectsWithTag("MainCamera");
        
        sizeofobjs = objs.Length;
        sizeofcameras = cameras.Length;
        if (sizeofobjs > 1)
        {
            Destroy(this);
        }
        if (sizeofcameras > 1)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);

        }
    }





}


