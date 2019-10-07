using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    public int damage = 50;
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ani.SetTrigger("BaseAttack");
        }
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            HealthManager hm = other.GetComponent<HealthManager>();
            hm.ApplyDamage(damage);
        }
    }
}
