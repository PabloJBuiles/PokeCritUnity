using System.Collections;
using System.Collections.Generic;

 public class AtackSkill : Skill
{
   

    public AtackSkill(double skillPower, afinity afinity, string name)
    {
        if (skillPower <= 0)
        {
            this.skillPower = 1;
        }
        else
        {
            this.skillPower = skillPower;
        }
      
        base.afinity = afinity;
        base.name = name;
    }

    public void UseSkill(Critter mCritter, Critter enemy, double dmgActual)
    {
        double affinityDmg = Affinity.CalculateAffinity(this.afinity, enemy.AfinityType);
        enemy.GetDmg((dmgActual + skillPower) * affinityDmg, mCritter.owner);
        base.UseSkill();
    }
}
