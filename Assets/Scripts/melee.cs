using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    private int damage;
    private Animator ani;
    private GameObject player;
    private void Start()
    {
        ani = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        damage = player.GetComponent<PlayerStat>().stats[1].GetCalculateStat();
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
            Debug.Log("hit damage = " + damage);
        }
    }
}
