using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string tagtoInteract;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tagtoInteract)
        {
            Interact();
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interact with basic");
    }
}
