using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBar : MonoBehaviour
{
    public ProgressBar Pb;
    private ExpSystem hm;
    private int enemyhealth;
    //public ProgressBarCircle PbC;

    private void Start()
    {
        hm = GameObject.FindWithTag("Player").GetComponent<ExpSystem>();
    }


    void FixedUpdate ()
    {
        
        Pb.BarValue=hm.currentexp;
        if (Pb.BarValue >= 99.5)
        {
            GetComponentInParent<AudioSource>().Play();
        }
    }
}
