using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDestroyer : MonoBehaviour
{
    private RoomTemp templates;
    private void Start()
    {
        Destroy(gameObject,6f);
        templates = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemp>();
        templates.rooms.Add(this.gameObject);
    }
}
