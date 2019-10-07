using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{


    public Rigidbody rb;
   
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }
    
    public void DestroyMe()
    {
        Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        float moveHorizontal = player.transform.position.x - this.transform.position.x ;
        float moveVertical = player.transform.position.z - this.transform.position.z ;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * 0.5f);
    }
}
