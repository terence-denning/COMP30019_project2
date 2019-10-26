using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    private Camera playcam;
    private HealthManager HM;
    private PlayerStat PS;
    private melee Melee;
    private Gun gun;
    private PointLight PL;
    public bool ModifyStatus = true;
    private bool OverKill;
    private float lerpindex;
    public float OverKillBar;
    public UnityEvent ESCBotton;
    public float Overkillbarreducespeed;
    public float knockbackforce;
    public GameObject pausemenuUI;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PS = GetComponent<PlayerStat>();
        HM = GetComponent<HealthManager>();
        Melee = GetComponentInChildren<melee>();
        gun = GetComponentInChildren<Gun>();
        PL = GetComponentInChildren<PointLight>();
        OverKillBar = 0;
    }
    //GameOver
    public void GameOver()
    {
        dunDestroy.DestroyAll();
        SceneManager.LoadScene("GameEnded");
    }
    public void IncreaseOverKill(float amount)
    {
        if (OverKill == false)
        {
            OverKillBar += amount;
        }
    }

    void OnCollisionStay(Collision other)
    {    
        if (other.gameObject.tag == "Enemy")
        {
            Vector3 dir = (this.transform.position - other.transform.position).normalized;
            rb.AddForce(dir * knockbackforce);  
            GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //volume
        GetComponent<AudioSource>().volume = GlobalOptions.volume;
        playcam = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        //PlayerStatusUpdate
        Melee.damage = PS.stats[1].GetCalculateStat();
        gun.damage = PS.stats[2].GetCalculateStat();
        //OverKill Session
        if (OverKillBar >= 100)
        {
            OverKillBar = 100;
        }
        
        lerpindex = OverKillBar / 100;
        PL.color = Color.Lerp(Color.white, Color.red, lerpindex);
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
        resetOnFall();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           ESCBotton.Invoke();
        }
    }

    //Reset
    private void resetOnFall()
    {
        if( this.transform.position.y < -10)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            this.transform.position = new Vector3(0.0f, 0.2f, 0.0f);
        }
    }
}
