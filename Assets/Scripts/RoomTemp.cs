using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomTemp : MonoBehaviour
{
    public GameObject[] bottomRm;
    public GameObject[] topRm;
    public GameObject[] leftRm;
    public GameObject[] rightRm;
    public List<GameObject> rooms;
    public float waittime;
    private bool spawnedBoss = false;
    private int ranE;
    private bool spwanpointT;
    public GameObject boss;
    public GameObject enemyspawnpoint1;
    public GameObject enemyspawnpoint2;
    public GameObject closeRm;
    private void Update()
    {
        if (waittime <= 0 && spwanpointT == false)
        {
            for (int i = 1; i < rooms.Count-2; i++)
            {
                ranE = Random.Range(0, 3);
                if (ranE == 1)
                {
                    Instantiate(enemyspawnpoint1, rooms[i].transform.position+new Vector3(0,1,0), Quaternion.identity);
                }else if (ranE == 2)
                {
                    Instantiate(enemyspawnpoint2, rooms[i].transform.position+new Vector3(0,1,0), Quaternion.identity);
                }
            }
            spwanpointT = true;
        }
    
        if (waittime <= 0 && spawnedBoss == false)
        {
            Instantiate(boss, rooms[rooms.Count-1].transform.position+new Vector3(0,1,0), Quaternion.identity);
                spawnedBoss = true;

        }
        else
        {
            waittime -= Time.deltaTime;
        }
    }
    public void spwanEnemy()
    {
     
      

    }
}
