using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

public class ExpSystem : MonoBehaviour
{
   public int requiredexp;
   public int currentexp ;
   public int level = 1;
   public bool modifiy = false;
   private GameObject player;
   public void gainexp(int exp)
   {
      currentexp += exp;
      Debug.Log("EXP");
   }

   private void Start()
   {
      player = GameObject.FindWithTag("Player");
      requiredexp = 100;
      currentexp = 0;
   }

   private void Update()
   {
      if (currentexp > requiredexp )
      {
         level++;
         player.GetComponent<PlayerStat>().skillpoint++;
         currentexp = 0;
         modifiy = true;
      }
   }
}
