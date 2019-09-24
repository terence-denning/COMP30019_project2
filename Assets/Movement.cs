using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if( Input.GetKey(KeyCode.Space) )
        {
            if( this.transform.position.y < 1)
            {
                rb.AddForce(new Vector3(0.0f, 4.0f, 0.0f) * speed);
            }
            
        }

        resetOnFall();
    }

    private void resetOnFall()
    {
        if( this.transform.position.y < -10)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            this.transform.position = new Vector3(0.0f, 1.0f, 0.0f);
        }
    }
}
