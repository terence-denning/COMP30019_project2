using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;   
    public float spawnTime = 3f;    
    public Transform[] spawnPoints;
    public int currentspwaned = 0; 
    public int maxOfSpawn = 5 ;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
        
    }

    // Update is called once per frame
    void Spawn ()
    {
        if (currentspwaned < maxOfSpawn)
        {
            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            currentspwaned++;
        }
    }
}
