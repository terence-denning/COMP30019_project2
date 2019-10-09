using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat 
{
    public List<StateBonus> StateAdd { get; set; }
    public int Basevalue { get; set; }
    public string Statname { get; set; }
    public string Statdesc { get; set; }
    public int Finalvalue { get; set; }

    public Stat(int basevalue, string statname, string statdces)
    {
        this.StateAdd = new List<StateBonus>();
        Basevalue = basevalue;
        Statname = statname;
        Statdesc = statdces;

    }

    public void Addstatebounus(StateBonus stateBonus)
    {
        this.StateAdd.Add(stateBonus);
    }

    public void removestatebouns(StateBonus stateBonus)
    {
        StateAdd.Remove(StateAdd.Find(x=> x.BonusV == stateBonus.BonusV));
    }

    public int GetCalculateStat()
    {
        Finalvalue = 0;
        for (int i = 0; i < StateAdd.Count; i++)
        {
            Finalvalue += StateAdd[i].BonusV;
        }
        Finalvalue += Basevalue;
        return Finalvalue ;
    }
        
}
