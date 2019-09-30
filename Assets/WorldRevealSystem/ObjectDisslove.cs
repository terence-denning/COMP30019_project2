using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDisslove : MonoBehaviour
{
    public Shader shader;
    public Texture dtex;
    public Texture maintex;
    // Start is called before the first frame update
    void Start()
    {
        Renderer r = this.gameObject.GetComponent<Renderer>();
        r.material.shader = this.shader;
        r.material.SetTexture("_MainTex",this.maintex);
        
    }

    // Update is called once per frame
    void Update()
    {
        Renderer r = this.gameObject.GetComponent<Renderer>();
    }
}
