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
    public bool Isknocl;
    private float knocktimer;
    public Color oringalcolor ;
    public Color dieingcolor;
    private Color lerpcolor;
    private float lerpindex;
    private MeshRenderer render;
        private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navg = GetComponent<NavMeshAgent>();
        timer = wonder;

    }

    // Update is called once per frame
    void Update()
    {
    
        
        timer += Time.deltaTime;
        //Player in close range
        if (isClose(player.transform.position, this.transform.position))
        {
            navg.SetDestination(player.transform.position);
        }

        
        if (timer >= wonder && isClose(player.transform.position, this.transform.position) == false)
        {
            Vector3 newPos = RandomNavSphere(transform.position, radius, -1);
            navg.SetDestination(newPos);
            timer = 0;
            reset = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && IsExplode)
        {
            GameObject exp = Instantiate(this.Explosion);
            exp.transform.position = this.transform.position;
            player.GetComponent<HealthManager>().ApplyDamage(30);
            Vector3 dir = -(transform.position - player.transform.position).normalized;
            player.GetComponent<Rigidbody>().AddForce(dir * 2000);
            Destroy(this.gameObject);
            Destroy(exp, 0.5f);
        }
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
    
    
}
