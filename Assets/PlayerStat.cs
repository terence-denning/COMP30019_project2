using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public List<Stat> stats = new List<Stat>();

    private void Start()
    {
        stats.Add(new Stat(100,"HP","Maximum HP"));
        stats.Add(new Stat(40,"Strength","Your Melee Damage "));
        stats.Add(new Stat(10,"Agility","Your Range Damage"));
        stats[0].Addstatebounus(new StateBonus(30));
        Debug.Log(stats[0].GetCalculateStat());
    }
}
