using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

/// <summary>
/// Creates wandering behaviour for a CharacterController.

public class WanderAI : MonoBehaviour
{
    public float movesSpeed = 3f;
    public float rotSpeed = 100f;
 
    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    
    // Start is called before the first frame update
    void Start()
    {
     
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            int rotateLorR = Random.Range(1, 2);
            if (rotateLorR == 1)
            {
                isRotatingLeft = true;
            }
            else
            {
                isRotatingRight = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isWandering == false) 
        {
            StartCoroutine(Wander());
 
        }
        if (isRotatingRight == true) 
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotatingLeft == true) 
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }

        if (isWalking == true)
        {
            transform.position += transform.forward * movesSpeed * Time.deltaTime;
        }



    }
    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWaite = Random.Range(1, 4);
        int rotateLorR = Random.Range(1, 2);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);
 
 
 
        isWandering = true;
 
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWaite);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
 
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
 
        }
        isWandering = false;
 
 
 
    }
}