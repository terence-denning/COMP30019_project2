using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleEnemyMovement : MonoBehaviour
{

    public GameObject Explosion;
    public float wonder;
    private float timer;
    public float radius;
    private NavMeshAgent navg;
    public bool IsExplode;
    private GameObject player;
    private bool reset;
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //navg = GetComponent<NavMeshAgent>();
        timer = wonder;
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //wodner around
        timer += Time.deltaTime;
     

        //Player in close range
        if (isClose(player.transform.position, this.transform.position))
        {
            //navg.SetDestination(player.transform.position);
            /*if (reset)
            {
                navg.SetDestination(this.transform.position);
                reset = false;
            }*/

            chasePlayer(player.transform.position);
            if (IsExplode)
            {
                explode(player.transform.position, this.transform.position);
            }
        }
       /* if (timer >= wonder && isClose(player.transform.position, this.transform.position) == false)
        {
            Vector3 newPos = RandomNavSphere(transform.position, radius, -1);
            navg.SetDestination(newPos);
            timer = 0;
            reset = true;
        }*/
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection =  UnityEngine.Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
    
    bool isClose(Vector3 obj1, Vector3 obj2)
    {
        if( (Math.Abs(obj1.x - obj2.x) < 3) && (Math.Abs(obj1.z - obj2.z) < 3))
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
