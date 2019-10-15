using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Movement : MonoBehaviour
{

    public Rigidbody rb;
    private int time = 0;
    private int teleportinterval = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // chase player
        GameObject player = GameObject.Find("Player");
        Vector3 dir = (player.transform.position - transform.position).normalized;
        if (isClose(player.transform.position, this.transform.position))
        {
            chasePlayer(player.transform.position);
            if (teleportinterval > 300)
            {
                Vector3 dpos = transform.position + dir;
                dpos.y = transform.position.y;
                Debug.Log("TelepotR!");
                transform.position = dpos ;
                teleportinterval = 0;
            } teleportinterval++;
        }
        
        
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
        rb.AddForce(xMov, 0, zMov);
    }
}
