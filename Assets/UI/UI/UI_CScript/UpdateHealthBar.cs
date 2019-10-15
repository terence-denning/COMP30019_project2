using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateHealthBar : MonoBehaviour {

    public ProgressBar Pb;
    private HealthManager hm;
    private float enemyhealth;
    //public ProgressBarCircle PbC;

    private void Start()
    {
        hm = GetComponentInParent<HealthManager>();
    }


    void FixedUpdate ()
    {
        enemyhealth = hm.currentHealth;
        Pb.BarValue = enemyhealth;
    }
}
