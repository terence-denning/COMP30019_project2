using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public Shader shader;
    public Texture maintex;
    public PointLight pointLight;
    private bool feedback;
    private float timeoffeedback = 10f;
    private float curtime;
    public GameObject player;
    // Start is called before the first frame update
    void OnEnable()
    {
        Renderer r = this.gameObject.GetComponent<Renderer>();
        r.material.shader = this.shader;
        r.material.SetTexture("_MainTex",this.maintex);
        player = GameObject.FindWithTag("Player");
        pointLight = GameObject.FindGameObjectWithTag("PointLight").GetComponent<PointLight>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            feedback = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        Renderer renderer = this.gameObject.GetComponent<Renderer>();
        if (pointLight != null)
        {
            renderer.material.SetColor("_PointLightColor", this.pointLight.color);
            renderer.material.SetVector("_PointLightPosition", this.pointLight.GetWorldPosition());
        }
        
        renderer.material.SetVector("_Worldpos", transform.position);
        if (player != null)
        {
            renderer.material.SetVector("_PlayerPos", player.transform.position);
        }
        
        if (feedback && curtime< timeoffeedback)
        {
            renderer.material.SetTexture("_MainTex",Texture2D.whiteTexture);
        }
        else if (feedback && curtime > timeoffeedback)
        {
            renderer.material.SetTexture("_MainTex",this.maintex);
            curtime = 0;
            feedback = false;
        }
        if(feedback)
        {
            curtime++;
        }
        
    }
}
