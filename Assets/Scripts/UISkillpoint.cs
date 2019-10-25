using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class UISkillpoint : MonoBehaviour
{
    // Start is called before the first frame update

    public Text text;
    public GameObject player;
    public PlayerStat PS;
    public int skillpoint;
    private void Start()
    {
        this.text = GetComponent<Text>();
        player = GameObject.FindWithTag("Player");
        PS = player.GetComponent<PlayerStat>();
    }

    private void Update()
    {
        skillpoint = PS.skillpoint;
        text.text = "Skill Point " + skillpoint;
    }
}
