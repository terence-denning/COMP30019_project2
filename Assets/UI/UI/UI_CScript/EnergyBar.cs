using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : MonoBehaviour
{

    public ProgressBar Pb;
    private PlayerControl hm;
    private float enemyhealth;
    //public ProgressBarCircle PbC;

    private void Start()
    {
        hm = GameObject.FindWithTag("Player").GetComponentInParent<PlayerControl>();
    }


    void FixedUpdate ()
    {
        enemyhealth = hm.OverKillBar;
        Pb.BarValue = enemyhealth;
    }
}
