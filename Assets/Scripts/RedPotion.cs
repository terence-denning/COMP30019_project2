using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPotion : InteractItem
{
   public int healpoint;
   public GameObject AS;
   public override void Interact()
   {
      GameObject player = GameObject.FindWithTag("Player");
      player.GetComponent<HealthManager>().RecoverHealth(healpoint);
      if (AS != null)
      {
         Instantiate(AS, transform.position, transform.rotation);
      }

      Destroy(transform.parent.gameObject);
      Destroy(this.gameObject);
   }


}
