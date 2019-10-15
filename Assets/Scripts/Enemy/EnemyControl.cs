using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class EnemyControl : MonoBehaviour
{


    private Rigidbody rb;
    private HealthManager HM;
    private GameObject player;
    public float increaseOverKill;
    private PlayerControl control;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        HM = GetComponent<HealthManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        control = player.GetComponent<PlayerControl>();
        HM.zeroHealthEvent.AddListener(delegate { control.IncreaseOverKill(increaseOverKill); });
    }
    
    public void DestroyMe()
    {
        Destroy(this);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<HealthManager>().ApplyDamage(10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        /*GameObject player = GameObject.Find("Player");
        float moveHorizontal = player.transform.position.x - this.transform.position.x ;
        float moveVertical = player.transform.position.z - this.transform.position.z ;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * 0.5f);*/
    }
}
