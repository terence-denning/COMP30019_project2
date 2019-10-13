using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public float ShowingEnviroment = 0;
    private Camera playcam;
    private HealthManager HM;
    private PlayerStat PS;
    private melee Melee;
    private Gun gun;
    private PointLight PL;
    private bool ModifyStatus = true;
    private bool OverKill;
    private float lerpindex;
    private float OverKillBar;
    public float Overkillbarreducespeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playcam = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        PS = GetComponent<PlayerStat>();
        HM = GetComponent<HealthManager>();
        Melee = GetComponentInChildren<melee>();
        gun = GetComponentInChildren<Gun>();
        PL = GetComponentInChildren<PointLight>();
        OverKillBar = 0;
    }

    public void IncreaseOverKill(float amount)
    {
        if (OverKill == false)
        {
            OverKillBar += amount;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerStatusUpdate
        if (ModifyStatus)
        {
            HM.MaximumHP(PS.stats[0].GetCalculateStat());
            Melee.damage = PS.stats[1].GetCalculateStat();
            gun.damage = PS.stats[2].GetCalculateStat();
            ModifyStatus = false;
        }
        //OverKill Session
        if (OverKillBar >= 100)
        {
            OverKillBar = 100;
        }
        
        Debug.Log("Remain bar " + OverKillBar);
        lerpindex = OverKillBar / 100;
        PL.color = Color.Lerp(Color.black, Color.red, lerpindex);
        PL.LightRange = Mathf.Lerp(3, 5, lerpindex);
        if (OverKill)
        {
            gun.overkill = true;
            Melee.Overkill = true;
            OverKillBar -= 0.1f * Overkillbarreducespeed;
        }

        if (OverKillBar < 1f)
        {
            gun.overkill = false;
            Melee.Overkill = false;
            OverKill = false;
        }

        if (Input.GetKeyDown(KeyCode.Q) && OverKillBar >= 99.5f)
        {
            OverKill = true;
        }

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
