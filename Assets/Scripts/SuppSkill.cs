using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppSkill: Skill
{
    esSkill sSkill;
    public SuppSkill(string name, esSkill sSkill)
    {            
        base.afinity = afinity.Dark;
        base.name = name;
        this.sSkill = sSkill;
        base.skillPower = 0;
    }

    public string UseSkill(Critter mCritter, double AtkUpB, double DefUpB, double SpdDwnB)
    {
        string statAumentada = "";
        if (uses <= 3)
        {
                
            switch (sSkill)
            {
                case esSkill.AtkUp:
                    mCritter.DmgActual = AtkUpB + (AtkUpB * 0.2);
                    statAumentada = " daño a aumentado un 20%";
                    break;
                case esSkill.DefUp:
                    mCritter.DefActual = DefUpB + (DefUpB * 0.2);
                    statAumentada = " defensa a aumentado un 20%";
                    break;
                case esSkill.SpdDwn:
                    mCritter.SpeedActual = SpdDwnB + (SpdDwnB * 0.3);
                    statAumentada = " velocidad a aumentado un 30%";
                    break;
                default:
                    break;
            }
              
            base.UseSkill();
            return "" + mCritter.CritName + " Uso " + name + " ahora su " + statAumentada;
        }

        return "" + mCritter.CritName + " sobrepaso el limite de usos de " + name;
    }
}