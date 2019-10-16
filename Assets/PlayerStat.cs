using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public List<Stat> stats = new List<Stat>();
    private GameObject player;
    public int skillpoint;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        stats.Add(new Stat(100,"HP","Maximum HP"));
        stats.Add(new Stat(40,"Strength","Your Melee Damage "));
        stats.Add(new Stat(10,"Agility","Your Range Damage"));
        stats[0].Addstatebounus(new StateBonus(30));
        Debug.Log(stats[0].GetCalculateStat());
    }
    
    public void increasehealth()
    {
        if (skillpoint > 0)
        {
            player.GetComponent<PlayerControl>().ModifyStatus = true;
            stats[0].Addstatebounus(new StateBonus(1));
            player.GetComponent<ExpSystem>().modifiy = false;
            skillpoint -= 1;
        }
    }
    public void increaseStrength()
    {
        if (skillpoint > 0)
        {
        player.GetComponent<PlayerControl>().ModifyStatus = true;
        stats[1].Addstatebounus(new StateBonus(1));
        player.GetComponent<ExpSystem>().modifiy = false;
        skillpoint -= 1;
        }
    }

    public void increaseAgility()
    {
        if (skillpoint > 0)
        {
        player.GetComponent<PlayerControl>().ModifyStatus = true;
        stats[2].Addstatebounus(new StateBonus(1));
        player.GetComponent<ExpSystem>().modifiy = false;
        skillpoint -= 1;
        }
    }
}
