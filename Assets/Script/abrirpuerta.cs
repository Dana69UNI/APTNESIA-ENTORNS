using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirpuerta : MonoBehaviour
{
    public Animator LaPuerta;
    bool isDoorLocked = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!isDoorLocked)
        {
            LaPuerta.Play("abrirPuerta3");
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (!isDoorLocked)
        {
            LaPuerta.Play("abrirPuerta3");
        }
    }

    public void DoorStatus()
    {
        isDoorLocked = !isDoorLocked;
    }
}

