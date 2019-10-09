using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public float ShowingEnviroment = 0;
    private bool trigger = false;
    private Camera playcam;
    private HealthManager HM;
    private PlayerStat PS;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playcam = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        PS = GetComponent<PlayerStat>();
        HM = GetComponent<HealthManager>();
        HM.MaximumHP(PS.stats[0].GetCalculateStat());
        //test
        HM.currentHealth -= 50;
    }
    

    // Update is called once per frame
    void Update()
    {
        
        //Look accroding to mouse;
        Vector2 mouseScreenPos = Input.mousePosition;
        float distanceFromCameraToXZPlane = playcam.transform.position.y;
        Vector3 screenPosWithZDistance = (Vector3)mouseScreenPos + (Vector3.forward * distanceFromCameraToXZPlane);
        Vector3 fixYcam = playcam.ScreenToWorldPoint(screenPosWithZDistance);
        fixYcam.y = this.transform.position.y;
        transform.LookAt(fixYcam,Vector3.up);
        //Movenment of Player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //rb.AddForce(movement * speed);
        rb.velocity = movement * speed;
        /*if( Input.GetKey(KeyCode.Space) )
        {
            if( this.transform.position.y < 1)
            {
                rb.AddForce(new Vector3(0.0f, 4.0f, 0.0f) * speed);
            }
        }*/
        resetOnFall();
        //EOF Movement
        //Player reveal
        Shader.SetGlobalFloat("_Radius", ShowingEnviroment);
       /* if (Input.GetKeyDown(KeyCode.F))
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
        }*/
        //Range Fire
        /*if (Input.GetButton("Fire2"))
        {
            Vector3 fireToWorldPos = Camera.main.ScreenToWorldPoint(screenPosWithZDistance);


            ProjectileController p = Instantiate<ProjectileController>(template);
            p.transform.position = this.transform.position + playcam.ScreenToWorldPoint(screenPosWithZDistance).normalized ;
            p.velocity = (fireToWorldPos - this.transform.position).normalized * 10.0f;
        }*/
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
