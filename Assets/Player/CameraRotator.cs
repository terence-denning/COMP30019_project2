using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        this.transform.position = player.transform.position;
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
