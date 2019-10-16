using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

public class ExpSystem : MonoBehaviour
{
   public int requiredexp = 10;
   public int currentexp = 0;
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
