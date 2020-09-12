using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // para que en algun momento el jugador pueda tener mas de 3 criaturas
    [SerializeField] public int MAXCritters  = 3;
    public List<Critter> CrittersOwned { get; private set; } = new List<Critter>();

    private void Start()
    {
        Debug.Log(CrittersOwned.Count +"" + gameObject);
        for (int i = 0; i < CrittersOwned.Count; i++)
        {
            Debug.Log(CrittersOwned[i].Moveset1.Count+"Skills de criaturas de " + gameObject);
        }
    }

    public void AgregarListaDeCriaturas(List<Critter> crittersOwned)
    {
        if (crittersOwned.Count <= MAXCritters)
        {
            CrittersOwned = crittersOwned;
            for (int i = 0; i < CrittersOwned.Count; i++)
            {
                crittersOwned[i].owner = this;
            }
        }
        else
        {
            Debug.LogError("La lista de criaturas agrgadas exede la capacidad de criaturas de este jugador " + gameObject);
        }
      
    }

    public void InicializarJugador(List<Critter> crittersOwned)
    {
        CrittersOwned = crittersOwned;
    }

    public void LoseCreatures( Critter critterLose)
    {
        CrittersOwned.Remove(critterLose);
    }

    public void AddCreatures(Critter critterAdd)
    {
        Debug.Log("Se esta intentando agragar un nuevo criter");
        if (CrittersOwned.Count + 1 <= MAXCritters)
        {
            CrittersOwned.Add(critterAdd);
            Debug.Log("Se agrego un critter ");
            critterAdd.GetCritterData();
        }
    }

    public void Attack(Critter enemyCritter, int skill, int critPos)
    {
        if (CrittersOwned.Count != 0 && CrittersOwned[critPos] != null && enemyCritter != null && CrittersOwned[critPos].Moveset1.Count >= skill && CrittersOwned[critPos].Moveset1[skill] is AtackSkill)
        {
            CrittersOwned[critPos].Atack(enemyCritter, CrittersOwned[critPos].Moveset1[skill] as AtackSkill);
        }

    }

    public string Buff(Critter critter, int skill)
    {
        if (CrittersOwned.Count != 0 && critter != null && critter.Moveset1.Count >= skill && critter.Moveset1[skill] is SuppSkill)
        {

            return critter.Buff(critter.Moveset1[skill] as SuppSkill);
        }

        return "algo salio mal";
    }
    

}


