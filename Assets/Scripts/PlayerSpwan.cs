using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpwan : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> objs;
    private GameObject player;
    private void Start()
    {
        objs = dunDestroy._ddolObjects;
        player = objs.Find((x) => x.CompareTag("Player"));
        Instantiate(player, transform.position, transform.rotation);
    }
}

