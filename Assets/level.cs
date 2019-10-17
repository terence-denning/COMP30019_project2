using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class level : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Text tex;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        tex = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        tex.text = "Level: " + player.GetComponent<ExpSystem>().level;
    }
}
