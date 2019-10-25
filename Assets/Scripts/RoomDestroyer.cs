using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDestroyer : MonoBehaviour
{
    private RoomTemp templates;
    void Start()
    {
        Destroy(gameObject,6f);
        templates = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemp>();
        templates.rooms.Add(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpwanPoint")){
            Destroy(other.gameObject);
        }
    }
}
