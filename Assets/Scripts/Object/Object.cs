using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public Shader shader;
    public Texture maintex;
    public PointLight pointLight;

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

    // Update is called once per frame
    void Update()
    {
        Renderer renderer = this.gameObject.GetComponent<Renderer>();
        renderer.material.SetColor("_PointLightColor", this.pointLight.color);
        renderer.material.SetVector("_PointLightPosition", this.pointLight.GetWorldPosition());
        renderer.material.SetVector("_Worldpos", transform.position);
        renderer.material.SetVector("_PlayerPos", player.transform.position);
        
    }
}
