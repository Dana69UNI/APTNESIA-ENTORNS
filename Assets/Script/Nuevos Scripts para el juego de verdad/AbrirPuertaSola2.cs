using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuertaSola2 : MonoBehaviour
{
    public Animator LaPuerta;

    private void OnTriggerEnter(Collider other)
    {
        LaPuerta.Play("abrirPuerta2");
    }
   
}


