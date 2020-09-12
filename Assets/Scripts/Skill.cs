using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class Skill
{
    internal afinity afinity;
    internal string name;
    internal int uses;
    internal double skillPower;
  

    public enum esSkill { AtkUp, DefUp, SpdDwn, Atck };

    public virtual void UseSkill() {
        uses++;
    }

}
