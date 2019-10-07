using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    private float ShowingEnviroment = 0;
    public float RevealSpeed = 3;
    private bool trigger = false;
    public float RevealMaxRange = 10;
    public float RevealMinRange = 0;

    private Camera playcam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playcam = GameObject.Find("PlayerCamera").GetComponent<Camera>();
    }
    

    // Update is called once per frame
    void Update()
    {
        //Look accroding to mouse;
        Vector2 mouseScreenPos = Input.mousePosition;
        float distanceFromCameraToXZPlane = playcam.transform.position.y;
        Vector3 screenPosWithZDistance = (Vector3)mouseScreenPos + (Vector3.forward * distanceFromCameraToXZPlane);
        transform.LookAt(playcam.ScreenToWorldPoint(screenPosWithZDistance),Vector3.up);
        //Movenment of Player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //rb.AddForce(movement * speed);
        rb.velocity = movement * (speed);
       // rb.position=(movement * (speed/10) + transform.position);
        /*if( Input.GetKey(KeyCode.Space) )
        {
            if( this.transform.position.y < 1)
            {
                rb.AddForce(new Vector3(0.0f, 4.0f, 0.0f) * speed);
            }
        }*/
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

    //Reset
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
