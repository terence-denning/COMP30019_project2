using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    public ProjectileController projectilePrefab;

    private int time = 0;
    private int lastBullet = 70;
    private Vector3 temppos;
    private Color lerpcolor;
    private float lerpindex;
    private MeshRenderer render;
    private float staringhealth;

    // Start is called before the first frame update
    void Start()
    {
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
        // spin movement
        this.transform.Rotate(new Vector3(0,time,0));


        // chase player
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            if (isClose(player.transform.position, this.transform.position))
            {
                chasePlayer(player.transform.position);
            }


            // shoot bullets at intervals
            if (time > lastBullet)
            {
                time = 0;
                temppos = new Vector3(transform.position.x, 0.2f, transform.position.z);
                ProjectileController p1 = Instantiate<ProjectileController>(projectilePrefab);
                p1.transform.position = temppos;
                p1.velocity = (transform.forward).normalized * 2.0f;

                ProjectileController p2 = Instantiate<ProjectileController>(projectilePrefab);
                p2.transform.position = temppos;
                p2.velocity = (-transform.forward).normalized * 2.0f;

                ProjectileController p3 = Instantiate<ProjectileController>(projectilePrefab);
                p3.transform.position = temppos;
                p3.velocity = (transform.right).normalized * 2.0f;

                ProjectileController p4 = Instantiate<ProjectileController>(projectilePrefab);
                p4.transform.position = temppos;
                p4.velocity = (-transform.right).normalized * 2.0f;
            }
        }

        time++;
    }

    bool isClose(Vector3 obj1, Vector3 obj2)
    {
        if ((Math.Abs(obj1.x - obj2.x) < 5) && (Math.Abs(obj1.z - obj2.z) < 5))
        {
            return true;
        }
        return false;
    }

    void chasePlayer(Vector3 playerPos)
    {
        float xMov;
        float zMov;
        if (playerPos.x > this.transform.position.x)
        {
            xMov = 0.01f;
        }
        else
        {
            xMov = -0.01f;
        }
        if (playerPos.z > this.transform.position.z)
        {
            zMov = 0.01f;
        }
        else
        {
            zMov = -0.01f;
        }
        this.transform.position += new Vector3(xMov, 0, zMov);
    }

    
}
