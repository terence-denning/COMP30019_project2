using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDead : MonoBehaviour
{
    public ParticleSystem paritcletemplate;
    public void bossdead()
    {
        Instantiate(paritcletemplate, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
