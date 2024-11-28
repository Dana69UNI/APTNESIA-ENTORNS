using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crearpuertaacercando : MonoBehaviour
{
    public Animator LaPuerta;

    private void OnTriggerEnter(Collider other)
    {
        LaPuerta.Play("abrirpuertaSola");
    }
    private void OnTriggerExit(Collider other)
    {
        LaPuerta.Play("cerrarpuertaSola");
    }
}
