using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject SimpleEnemyTemplate;
    // Start is called before the first frame update
    void Start()
    {
        GameObject simpleEnemy = GameObject.Instantiate<GameObject>(SimpleEnemyTemplate);
        simpleEnemy.transform.parent = this.transform;
        simpleEnemy.transform.localPosition += new Vector3(0, 10.0f, 0);
    }


}
