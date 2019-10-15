using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
        //public ProgressBar Pb;
        private HealthManager hm;
        private float enemyhealth;
        private ProgressBarCircle PbC;

        private void Start()
        {
            PbC = GetComponent<ProgressBarCircle>();
            hm = GameObject.FindWithTag("Player").GetComponentInParent<HealthManager>();
        }


        void FixedUpdate ()
        {
           
            enemyhealth = hm.currentHealth;
            PbC.BarValue = enemyhealth;
        }

}
