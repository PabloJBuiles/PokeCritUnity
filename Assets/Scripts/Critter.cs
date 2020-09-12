using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Critter 
{
    public Player owner;
    private string critName = "";
    private double baseHP;
    public double actualHP { get; private set; }
    private double baseAttack, actualAttack;
    private double baseSpeed, actualSpeed;
    private double baseDefense, actualDefence;
    private afinity afinityType;
    public Critter target;
    private List<Skill> Moveset = new List<Skill>();
    private Sprite mSprite;


    public Critter(double baseHp, double dmgBase, double speedBase, double defBase, string critName,
        afinity afinityType, Sprite msprite)
    {
        mSprite = msprite;
        //Verificar el daño entr 10 y 100
        if (dmgBase > 100)
        {
            this.DmgBase = 100;
        }
        else if (dmgBase < 10)
        {
            this.DmgBase = 10;
        }
        else
        {
            this.DmgBase = dmgBase;
        }

        //verificar defensa entre 10 y 100
        if (defBase > 100)
        {
            this.baseDefense = 100;
        }
        else if (defBase < 10)
        {
            this.baseDefense = 10;
        }
        else
        {
            this.baseDefense = defBase;
        }

        //verificar si la velocidad 1 y 50
        if (speedBase > 50)
        {
            this.baseSpeed = 50;
        }
        else if (speedBase < 1)
        {
            this.baseSpeed = 1;
        }
        else
        {
            this.baseSpeed = speedBase;
        }

        this.baseHP = baseHp;
        this.critName = critName;
        this.afinityType = afinityType;

        actualHP = this.baseHP;
        actualAttack = this.baseAttack;
        actualDefence = this.baseDefense;

        
    }


    public afinity AfinityType
    {
        get => afinityType;
    }

    public double SpeedActual
    {
        get => actualSpeed;
        set => actualSpeed = value;
    }

    public double DmgActual
    {
        set => actualAttack = value;
    }

    public double DefActual
    {
        set => actualDefence = value;
    }

    public double DmgBase
    {
        set => baseAttack = value;
    }

    internal List<Skill> Moveset1
    {
        get => Moveset;
    }

    public string CritName
    {
        get => critName;
 
    }

    public Sprite MSprite
    {
        get => mSprite;
        set => mSprite = value;
    }

    public void GetDmg(double dmg, Player enemytrainer)
    {
        actualHP -= dmg;
        if (!(actualHP <= 0)) return;
        if (owner.CrittersOwned.Count > 0)
        {
            owner.LoseCreatures(this); 
            if (enemytrainer.CrittersOwned.Count  + 1 <= enemytrainer.MAXCritters )
                enemytrainer.AddCreatures(this);
            actualHP = 1;
            GameManager.ActualizarNombres();
        }
        else
        {
            Debug.LogWarning("El jugador se quedo sin critters y deveria perder");
            //El jugador pierde
        }
    }

    public void Atack(Critter enemyCritter, AtackSkill atackSkill)
    {
        atackSkill.UseSkill(this, enemyCritter, actualAttack);
    }

    public string Buff(SuppSkill suppSkill)
    {
       return suppSkill.UseSkill(this, baseAttack, baseDefense, baseSpeed);
    }

    public void AgregarMoveSet(List<Skill> newMoveSet)
    {
        Moveset = newMoveSet;
    }
    public void GetCritterData()
    {
        string data =
                "VidaAcutal " + actualHP + " Vida Maxima " + baseHP + " daño base " + baseAttack + " daño actual " +
                actualAttack + " defensa base " + baseDefense +
                " defensa actual " + actualDefence + " velocidad base " + baseSpeed + " Velocidad actual " + actualSpeed +
                " Afinidad " + afinityType
            ;


        Debug.Log(data);
    }
}

