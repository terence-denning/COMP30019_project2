﻿using System;
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
        objs = dunDestroy._ddolObjects;
        if((objs.Find((x)=>x.name == "BackgroundMusic")==null))
        {
            dunDestroy.DontDestroyOnLoad(this.gameObject);
        }

    }
}