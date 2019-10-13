using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPotion : InteractItem
{
    public float SpeedUpTime;
    public float SpeedUpFactor;
    public override void Interact()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponentInChildren<Gun>().speedupitem(true,SpeedUpTime,SpeedUpFactor);
        Destroy(transform.parent.gameObject);
        Destroy(this.gameObject);
        
    }
}
