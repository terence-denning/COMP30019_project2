using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyMovement : MonoBehaviour
{

    public GameObject Explosion;

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");

        if( isClose(player.transform.position, this.transform.position))
        {
            chasePlayer(player.transform.position);
            explode(player.transform.position, this.transform.position);
        }
        
    }

    bool isClose(Vector3 obj1, Vector3 obj2)
    {
        if( (Math.Abs(obj1.x - obj2.x) < 5) && (Math.Abs(obj1.z - obj2.z) < 5))
        {
            return true;
        }
        return false;
    }

    void chasePlayer(Vector3 playerPos)
    {
        float xMov;
        float zMov;
        if(playerPos.x > this.transform.position.x)
        {
            xMov = 0.01f;
        } else
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

    void explode(Vector3 obj1, Vector3 obj2)
    {
        if ((Math.Abs(obj1.x - obj2.x) < 0.5f) && (Math.Abs(obj1.z - obj2.z) < 0.5f))
        {
            // Create explosion effect
            GameObject exp = Instantiate(this.Explosion);
            exp.transform.position = this.transform.position;
            
            Destroy(this.gameObject);
            Destroy(exp, 0.5f);
        }
    }
}
