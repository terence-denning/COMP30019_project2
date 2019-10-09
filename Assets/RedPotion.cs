using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotion : InteractItem
{
   public int healpoint;

   public override void Interact()
   {
      GameObject player = GameObject.FindWithTag("Player");
      player.GetComponent<HealthManager>().RecoverHealth(healpoint);
      Destroy(transform.parent.gameObject);
      Destroy(this.gameObject);
   }


}
