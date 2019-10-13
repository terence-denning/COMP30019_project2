using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractItem : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Interact();
        }
    }

    public virtual void Interact()
    {
        Debug.Log("item");
    }
    
    void Update()
    {
        this.transform.Rotate(0,1,0);
    }
}
