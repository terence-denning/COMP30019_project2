using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 50;
    private Animator ani;
    public float intervel;
    private float currentshot ;
    public ProjectileController template;
    public 
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        currentshot = intervel;
    }

    // Update is called once per frame
    void Update()
    {    
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
                p.velocity = (transform.forward).normalized * 10.0f;
                currentshot = 0;
            }

            currentshot += Time.deltaTime;
        }

        if (Input.GetButtonUp("Fire2"))
        {
            ani.SetBool("Dawrgun",false);
        }
    }
}
