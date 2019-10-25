using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpwan : MonoBehaviour
{
    public int openningDirection;
    //1 bot
    //2 top
    //3 left
    //4 right
    private RoomTemp template;
    private int ran;
    private float cur;
    public bool spawned = false;
    public float waittime = 500f;

    

    void Start()
    {
        Destroy(gameObject,waittime);
        template = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemp>();
        Invoke("Spwan",0.01f);
    }

    void OnTriggerStay(Collider other)
    {
        if (cur > waittime)
        {
            if (other.CompareTag("SpwanPoint"))
                    {
                        if (other.GetComponent<RoomSpwan>().spawned == false && spawned == false)
                        {
                            if (template.closeRm != null) Instantiate(template.closeRm, transform.position, Quaternion.identity);
                            Destroy(this.gameObject);
                        }
                        spawned = true;
                    }
        }
        else
        {
            cur++;
        }
        

           //Destroy(this.gameObject);

    }


    void Spwan()
    {
        if (spawned == false)
            {
                if (openningDirection == 1)
                {
                    ran = Random.Range(0, template.bottomRm.Length);
                    Instantiate(template.bottomRm[ran], transform.position, template.bottomRm[ran].transform.rotation);

                }
                else if (openningDirection == 2)
                {
                    ran = Random.Range(0, template.topRm.Length);
                    Instantiate(template.topRm[ran], transform.position, template.topRm[ran].transform.rotation);


                }
                else if (openningDirection == 3)
                {
                    ran = Random.Range(0, template.leftRm.Length);
                    Instantiate(template.leftRm[ran], transform.position, template.leftRm[ran].transform.rotation);

                }
                else if (openningDirection == 4)
                {
                    ran = Random.Range(0, template.rightRm.Length);
                    Instantiate(template.rightRm[ran], transform.position, template.rightRm[ran].transform.rotation);

                }

                spawned = true;
              
            }
        
}


}
