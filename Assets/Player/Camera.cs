using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public float rotateSpeed = 8f;
    private Vector3 offset;
    private float moveAround;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; 
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        GameObject player = GameObject.Find("Player");
        float playerX = player.transform.position.x;
        float playerZ = player.transform.position.z;

        Quaternion angle = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*speed, Vector3.up);
        offset = angle * offset;
        

        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform);
        
    }
}
