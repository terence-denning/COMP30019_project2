using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public float rotateSpeed = 8f;
    private Vector3 offset;
    private float moveAround;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; 
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        GameObject player = GameObject.Find("Player");

        offset += new Vector3(5 * Time.deltaTime, 0, 0);

        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform);
        
    }
}
