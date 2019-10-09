using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 50;
    private Animator ani;
    public float intervel;
    private float startintervel;
    private float currentshot ;
    public ProjectileController template;
    private float speedup;
    private float timeOfspeedup;
    private bool speedupItem = false;
    // Start is called before the first frame update
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
            Vector2 mouseScreenPos = Input.mousePosition;
            float distanceFromCameraToXZPlane = Camera.main.transform.position.y;
            Vector3 screenPosWithZDistance = (Vector3)mouseScreenPos + (Vector3.forward * distanceFromCameraToXZPlane);
            ani.SetBool("Dawrgun",true);
            Vector3 fireToWorldPos = Camera.main.ScreenToWorldPoint(screenPosWithZDistance);
            fireToWorldPos.y = transform.position.y;
            if (currentshot > intervel)
            {
                ProjectileController p = Instantiate<ProjectileController>(template);
                p.transform.position = this.transform.position;
                p.transform.rotation = transform.localRotation;
                p.GetComponent<Rigidbody>().velocity = (transform.forward).normalized * 5.0f;
                currentshot = 0;
            }

            currentshot += Time.deltaTime;
        }

        if (Input.GetButtonUp("Fire2"))
        {
            ani.SetBool("Dawrgun",false);
            currentshot = intervel;
        }
    }
}
