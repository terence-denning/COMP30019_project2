using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Movement : MonoBehaviour
{
    public GameObject SimpleEnemyTemplate;

    private int time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // spawn bomb enemy
        if( time > 500)
        {
            time = 0;
            GameObject simpleEnemy = GameObject.Instantiate<GameObject>(SimpleEnemyTemplate);
            //simpleEnemy.transform.parent = this.transform;
            simpleEnemy.transform.localPosition = new Vector3(
                    this.transform.position.x+1.0f,
                    0,
                    this.transform.position.z
                    );
        }
        time++;
        
    }
}
