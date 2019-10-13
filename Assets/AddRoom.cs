using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemp templates;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemp>();
        templates.rooms.Add(this.gameObject);
    }
    
    
}
