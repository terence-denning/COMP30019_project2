using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaobleCam : MonoBehaviour
{
    public GameObject player;
    public float damp = 1;
    private Vector3 offset;

    private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0,6,-3);
        rotation = new Quaternion(62f,0f,0f,0);
        //transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dpos;
        dpos = player.transform.position + offset;
        transform.position = dpos;
        //transform.LookAt(player.transform.position);
    }
}
