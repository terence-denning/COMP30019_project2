using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaobleCam : MonoBehaviour
{
    public GameObject player;
    public float damp = 1;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dpos, pos;
        dpos = player.transform.position + offset;
        pos = Vector3.Lerp(transform.position, dpos, Time.deltaTime + damp);
        transform.position = dpos;
        transform.LookAt(player.transform.position);
    }
}
