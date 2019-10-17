using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestropBGM : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> objs;
    private void Awake()
    {
        GameObject bgm = GameObject.FindGameObjectWithTag("music");
        objs = dunDestroy2._ddolObjects;
        if((objs.Find((x)=>x.name == "BackgroundMusic")==null))
        {
            dunDestroy2.DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
