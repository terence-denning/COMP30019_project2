using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileController : MonoBehaviour {

    public Vector3 velocity;

    public int damageAmount ;
    public string tagToDamage;

    // Update is called once per frame
    void Update () {
        this.transform.Translate(velocity * Time.deltaTime);
	}

    // Handle collisions
   
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tagToDamage)
        {
            // Damage object with relevant tag
            HealthManager healthManager = col.GetComponent<HealthManager>();
            healthManager.ApplyDamage(damageAmount);
            if (tagToDamage == "Player")
            {
                col.gameObject.GetComponent<AudioSource>().Play();
            }

            // Destroy self
            Destroy(this.gameObject);
        }
        else if(col.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
    void OnBecameInvisible () {
        Destroy(this.gameObject);
    }
}
