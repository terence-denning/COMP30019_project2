using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
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
        if (Input.GetButtonDown("Fire1"))
        {
            ani.SetTrigger("BaseAttack");
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
            HealthManager hm = other.GetComponent<HealthManager>();
            hm.ApplyDamage(CurrentDamge);
            Debug.Log("hit damage = " + CurrentDamge);
        }
    }
}
