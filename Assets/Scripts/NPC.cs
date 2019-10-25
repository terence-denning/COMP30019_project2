using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.F)){
            Interact();
        }
    }

    public void Interact()
    {
        Debug.Log("Iam NPC");
    }
}
