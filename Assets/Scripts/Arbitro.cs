using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class Arbitro : MonoBehaviour
{
    private static Arbitro instance;
    [SerializeField]public Player jugador;
    [SerializeField]public Player enemigo;
    public string ultimaSuppSkillUtilizada;

    public enum turno
    {
        jugador, ia, cambioDeTurno
    }

    public  turno TurnoActual { get; private set; }
    private turno turnoAnterior;

    [Header("Stats del criter aliado")] [SerializeField]
    private float vidaActual;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }
    // Start is called before the first frame update

    public void AtackSlotJugador(int slot)
    {
        UseSkill(turno.jugador, jugador, slot, enemigo);
        
    }

    public void AtackSlotEnemy(int slot)
    {
        UseSkill(turno.ia, enemigo, slot, jugador);
        
    }

    private void UseSkill(turno turnode, Player atacante, int skillSlot, Player objetivo)
    {
        if (TurnoActual != turnode) return;
        if(atacante.CrittersOwned[0].Moveset1[skillSlot] is AtackSkill)
        {
            atacante.Attack(objetivo.CrittersOwned[0], skillSlot, 0);
        }

        if(atacante.CrittersOwned[0].Moveset1[skillSlot] is SuppSkill)
        {
            ultimaSuppSkillUtilizada = atacante.Buff(atacante.CrittersOwned[0], skillSlot);
            GameManager.MostrarSuppSkill();
        }
        IniciarCambiDeTurno();
        Debug.Log(atacante.gameObject +" Uso! " + atacante.CrittersOwned[0].Moveset1[skillSlot].name);
    }

    public void IniciarCambiDeTurno()
    {
        GameManager.ActualizarVida();
        turnoAnterior = TurnoActual;
        TurnoActual = turno.cambioDeTurno;
        GameManager.ActivarDesactivarBotones();
        Invoke("CambioDeTurno", 3.7f);
    }

    private void CambioDeTurno()
    {
        switch (turnoAnterior)
        {
            case turno.jugador:
                TurnoActual = turno.ia;
                break;
            case turno.ia:
                TurnoActual = turno.jugador;
                break;
            case turno.cambioDeTurno:
                break;
            default:
                Debug.LogError(nameof(turnoAnterior) + " " + turnoAnterior);
                break;
        }
        GameManager.ActivarDesactivarBotones();

    }
    
}
