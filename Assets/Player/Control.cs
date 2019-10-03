using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    public Rigidbody rb;
    


    public float speed;
    private float ShowingEnviroment = 0;
    public float RevealSpeed = 3;
    private bool trigger = false;
    public float RevealMaxRange = 10;
    public float RevealMinRange = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        

        //Movement of Player
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
        //EOF Movement
        
        //Player On fire
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (trigger)
            {
                trigger = false;
                Debug.Log("change false");
            }
            else
            {
                trigger = true;
                Debug.Log("change true");
            }
        }
        if (trigger)
        {
            ShowingEnviroment += RevealSpeed/30;
            if (ShowingEnviroment >= RevealMaxRange)
            {
                ShowingEnviroment = RevealMaxRange;
            }
            Shader.SetGlobalFloat("_Radius", ShowingEnviroment);
        }else{
            ShowingEnviroment -= RevealSpeed/30;
            if (ShowingEnviroment <= RevealMinRange)
            {
                ShowingEnviroment = RevealMinRange;
            }
            Shader.SetGlobalFloat("_Radius",ShowingEnviroment);
        }
        
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
