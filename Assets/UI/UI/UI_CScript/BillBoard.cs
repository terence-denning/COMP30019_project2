using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Camera MyCamera;

    private void OnEnable()
    {
        MyCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        transform.LookAt(transform.position + MyCamera.transform.rotation * Vector3.back,
                          MyCamera.transform.rotation * Vector3.down);
    }
}
