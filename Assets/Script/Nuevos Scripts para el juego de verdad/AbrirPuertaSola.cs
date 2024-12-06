using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuertaSola : MonoBehaviour
{
    public Animator LaPuerta;

    private void OnTriggerEnter(Collider other)
    {
        LaPuerta.Play("abrirPuerta");
    }
    private void OnTriggerExit(Collider other)
    {
        LaPuerta.Play("cerrarPuerta");
    }
}

