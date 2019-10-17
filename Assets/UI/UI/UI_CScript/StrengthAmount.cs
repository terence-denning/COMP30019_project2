using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrengthAmount : MonoBehaviour
{
    private float Amount;
    private string StrengthTxt;
    private GameObject player;
    private PlayerStat PS;
    private int strgenth;
    private Slider bar;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        PS = player.GetComponent<PlayerStat>();
        bar = GetComponentInParent<Slider>();
    }

    void Update()
    {
        strgenth = PS.stats[1].GetCalculateStat();
        bar.value = strgenth;
        Amount = GameObject.Find("StrengthBar").GetComponent<Slider>().value;
        GameObject.Find("StrengthAmountText").GetComponent<Text>().text = Amount + "/ 100";
    }

}
