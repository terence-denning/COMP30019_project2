using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaobleCam : MonoBehaviour
{
    public GameObject player;
    public float damp = 1;
    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    private Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0,6,-3);
        rotation = new Quaternion(62f,0f,0f,0);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 dpos;
        
        dpos = player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, dpos, ref velocity ,  0.3f);
    }
}
