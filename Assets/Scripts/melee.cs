using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    public int damage;
    private Animator ani;
    private GameObject player;
    public bool Overkill;
    private int CurrentDamge;
    private void Start()
    {
        ani = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        GetComponent<AudioSource>().volume = GlobalOptions.volume;
        if (Input.GetButtonDown("Fire1"))
        {
            ani.SetTrigger("BaseAttack");
            GetComponent<AudioSource>().Play();
        }

        if (Overkill)
        {
            CurrentDamge += 50;
        }
        else
        {
            CurrentDamge = damage;
        }
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Vector3 dir = -(player.transform.position - other.transform.position).normalized;
           other. GetComponent<Rigidbody>().AddForce(dir * 200);
            HealthManager hm = other.GetComponent<HealthManager>();
            hm.ApplyDamage(CurrentDamge);
        }
    }


}
