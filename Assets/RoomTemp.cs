using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemp : MonoBehaviour
{
    public GameObject[] bottomRm;
    public GameObject[] topRm;
    public GameObject[] leftRm;
    public GameObject[] rightRm;
    public List<GameObject> rooms;
    public float waittime;
    private bool spawnedBoss = false;
    public GameObject boss;
    private void Update()
    {

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
}
