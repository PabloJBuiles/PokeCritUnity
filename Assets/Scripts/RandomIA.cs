using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIA : MonoBehaviour
{
    [SerializeField]private Arbitro _arbitro;
    private int randum;

    // Start is called before the first frame update
    private void Start()
    {
        if (_arbitro != null)
        {
            InvokeRepeating("SeleccionarAtaque", 2f, 3f);  
        }
       
    }


    public void SeleccionarAtaque()
    {
        if (_arbitro.TurnoActual != Arbitro.turno.ia) return;
        randum = Random.Range(0, 3);
        _arbitro.AtackSlotEnemy(randum);
    }
}
