using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : InteractItem
{
    public float SpeedUpTime;
    public float SpeedUpFactor;
    public GameObject AS;

   

    public override void Interact()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponentInChildren<Gun>().speedupitem(true,SpeedUpTime,SpeedUpFactor);
        if (AS != null)
        {
            Instantiate(AS, transform.position, transform.rotation);
        }
        Destroy(transform.parent.gameObject);
        Destroy(this.gameObject);
        
        
    }
}
