using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage;
    private Animator ani;
    public float intervel;
    private float startintervel;
    private float currentshot ;
    public ProjectileController template;
    private float speedup;
    private float timeOfspeedup;
    private bool speedupItem = false;
    public bool overkill;
    void Start()
    {
        ani = GetComponent<Animator>();
        currentshot = intervel;
        startintervel = intervel;
    }

    public void speedupitem(bool trigger, float tos, float speed)
    {
        this.speedup = speed;
        this.timeOfspeedup = tos;
        this.speedupItem = trigger;
    }

    public void Projectile(int damage,Vector3 pos, Quaternion rotate)
    {
        ProjectileController p = Instantiate<ProjectileController>(template);
        p.transform.position = pos;
        p.transform.rotation = rotate;
        p.damageAmount = damage;
        p.GetComponent<Rigidbody>().velocity = (transform.forward).normalized * 7.0f;
    }
    // Update is called once per frame
    void Update()
    {
        //PickupSpeedBosster
        if (speedupItem)
        {
            intervel  -= 0.1f*speedup;
            speedupItem = false;
        }

        timeOfspeedup -= Time.deltaTime ;
        if (timeOfspeedup <= 0)
        {
            intervel = startintervel;
        }
        
        //Fire Gun
        if (Input.GetButton("Fire2"))
        {

            if (currentshot > intervel && overkill == false)
            {
                /*ProjectileController p = Instantiate<ProjectileController>(template);
                p.transform.position = this.transform.position;
                p.transform.rotation = transform.localRotation;
                p.damageAmount = damage;
                p.GetComponent<Rigidbody>().velocity = (transform.forward).normalized * 7.0f;
                currentshot = 0;*/
                Projectile(damage,transform.position,transform.localRotation);
                currentshot = 0;
            }
            currentshot += Time.deltaTime;
            if (currentshot > intervel && overkill == true)
            {
                Projectile(damage,this.transform.position,transform.localRotation);
                Projectile(damage, transform.TransformPoint(new Vector3(1f,0,0)),transform.localRotation);
                Projectile(damage,transform.TransformPoint(new Vector3(-1f,0,0)),transform.localRotation);
                currentshot = 0;
            }
            /*{
                ProjectileController p = Instantiate<ProjectileController>(template);
                ProjectileController p2 = Instantiate<ProjectileController>(template);
                ProjectileController p3 = Instantiate<ProjectileController>(template);
                p.transform.position = this.transform.position;
                p.transform.rotation = transform.localRotation;
                p.damageAmount = damage;
                p.GetComponent<Rigidbody>().velocity = (transform.forward).normalized * 7.0f;
                currentshot = 0;
            }*/
        }

        if (Input.GetButtonUp("Fire2"))
        {
            ani.SetBool("Dawrgun",false);
            currentshot = intervel;
        }
    }
}
