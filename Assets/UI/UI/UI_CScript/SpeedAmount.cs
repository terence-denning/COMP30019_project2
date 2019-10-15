using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeedAmount : MonoBehaviour
{
    private float Amount;
    private string SpeedTxt;
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
        strgenth = PS.stats[2].GetCalculateStat();
        bar.value = strgenth;
        Amount = GameObject.Find("SpeedBar").GetComponent<Slider>().value;
        GameObject.Find("SpeedAmountText").GetComponent<Text>().text = Amount + "/ 100";

    }
}
