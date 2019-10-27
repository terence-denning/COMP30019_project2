using System;
using UnityEngine;
using System.Collections;

public class PointLight : MonoBehaviour {

    public Color color;
    public float LightRange = 0;
    public Vector3 GetWorldPosition()
    {
       return this.transform.position;
    }

    private void Update()
    {
        Shader.SetGlobalFloat("_LightRange",LightRange);
        Shader.SetGlobalVector("_PointLightPosition",transform.position);
        Shader.SetGlobalColor("_PointLightColor",color);
    }
}
