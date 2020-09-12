using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CrittersFac : MonoBehaviour
{
    [SerializeField, Tooltip("Aqui va el Arbitro que contiene la info del jugador humano y de la Ia")]
    private Arbitro _arbitro;
    [Header("Modificar los crites y a quien le pertenecen"),]
    [Header("Critters"), Tooltip("Usar la misma cantidad de critters para todo, si no, peta :'v")]
    [SerializeField, Min(1)]
    private int[] hpBase;

    [SerializeField, Range(10, 100)] private int[] dmgBase;
    [SerializeField, Range(1, 50)] private int[] speedBase;
    [SerializeField, Range(10, 100)] private int[] defBase;
    [SerializeField] private string[] critName;
    [SerializeField] private afinity[] afinityType;
    [FormerlySerializedAs("critterDelJugador")] [SerializeField] private critterDe[] perteneceA;
    [SerializeField] private Sprite[] imgCrit; 
    
    
    public List<Critter> CrittersPlayer { get; } = new List<Critter>();
    public List<Critter> CrittersEnemy { get; } = new List<Critter>();

    enum critterDe
    {
        jugador,
        enemigo,
        nadie
    }

    private void Awake()
    {
        for (var i = 0; i < hpBase.Length; i++)
        {
            Critter _critter =
                new Critter(hpBase[i], dmgBase[i], speedBase[i], defBase[i], critName[i], afinityType[i], imgCrit[i]);
            if (perteneceA[i] == critterDe.jugador)
            {
                CrittersPlayer.Add(_critter);
            }
            else if (perteneceA[i] == critterDe.enemigo)
            {
                CrittersEnemy.Add(_critter);
            }
        }
    }

    // Start is called before the first frame update


    public void AgregarSkillSetJugador(List<Skill> listaSkills, int critter)
    {
        CrittersPlayer[critter].AgregarMoveSet(listaSkills);
       
    }
    
    public void AgregarSkillSetEnemigo(List<Skill> listaSkills, int critter)
    {
        CrittersEnemy[critter].AgregarMoveSet(listaSkills);
    }

    public void AgregarCritters()
    {
        _arbitro.jugador.AgregarListaDeCriaturas(CrittersPlayer);
        _arbitro.enemigo.AgregarListaDeCriaturas(CrittersEnemy);
    }
    
}