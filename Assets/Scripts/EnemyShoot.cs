using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public ProjectileController projectilePrefab;

    private int time = 0;
    private int lastBullet = 70;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (time > lastBullet)
        {
            time = 0;

            ProjectileController p = Instantiate<ProjectileController>(projectilePrefab);
            p.transform.position = this.transform.position;
            p.velocity = (transform.forward).normalized * 2.0f;
        }
        time++;
    }
}
