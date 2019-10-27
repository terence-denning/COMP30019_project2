using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Movement : MonoBehaviour
{

    public Rigidbody rb;
    private int teleportinterval = 0;
    private Color lerpcolor;
    private float lerpindex;
    private MeshRenderer render;
    private float staringhealth;
    private Vector3 spwanpos;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spwanpos = this.transform.position;
        render = this.gameObject.GetComponent<MeshRenderer>();
        render.material.SetColor("_Color",Color.white);
        staringhealth = (float)GetComponent<HealthManager>().startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Color reflect health
        
        lerpindex = (staringhealth-GetComponent<HealthManager>().currentHealth) / staringhealth;
        lerpcolor = Color.Lerp(Color.white,Color.red,lerpindex);
        render.material.SetColor("_Color",lerpcolor);
        // chase player
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            Vector3 dir = (player.transform.position - transform.position).normalized;
            if (isClose(player.transform.position, this.transform.position))
            {
                chasePlayer(player.transform.position);
                if (teleportinterval > 300)
                {
                    Vector3 dpos = transform.position + dir;
                    dpos.y = transform.position.y;
                    Debug.Log("TelepotR!");
                    transform.position = dpos;
                    teleportinterval = 0;
                }

                teleportinterval++;
            }
        }

        resetOnFall();
        
        
    }

    bool isClose(Vector3 obj1, Vector3 obj2)
    {
        if ((Math.Abs(obj1.x - obj2.x) < 5) && (Math.Abs(obj1.z - obj2.z) < 5))
        {
            return true;
        }
        return false;
    }
    private void resetOnFall()
    {
        if( this.transform.position.y < -10)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            this.transform.position = spwanpos;
        }
    }

    void chasePlayer(Vector3 playerPos)
    {
        float xMov;
        float zMov;
        if (playerPos.x > this.transform.position.x)
        {
            xMov = 2.0f;
        }
        else
        {
            xMov = -2.0f;
        }
        if (playerPos.z > this.transform.position.z)
        {
            zMov = 2.0f;
        }
        else
        {
            zMov = -2.0f;
        }
        rb.AddForce(xMov*20, 0, zMov*20);
    }
}
