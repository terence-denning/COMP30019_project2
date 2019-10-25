using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBonus 
{
    public int  BonusV { get; set; }

    public StateBonus(int bonus)
    {
        BonusV = bonus;
        Debug.Log("new stat init");
    }
}
