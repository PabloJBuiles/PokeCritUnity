using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("Desactivar", 3.5f);
    }

    private void OnDisable()
    {
        CancelInvoke("Desactivar");
    }

    void Desactivar()
    {
        this.gameObject.SetActive(false);
    }
}
