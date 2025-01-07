using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirpuerta2 : MonoBehaviour
{
    public Animator LaPuerta; // Animador de la puerta
    private bool isDoorLocked = true; // Estado de la puerta (cerrada por defecto)
    private bool hasGivenApple = false; // Estado de si se dio la manzana

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si la puerta está desbloqueada
        if (!isDoorLocked)
        {
            LaPuerta.Play("abrirPuerta3");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si la puerta está desbloqueada
        if (!isDoorLocked)
        {
            LaPuerta.Play("abrirPuerta3");
        }
    }

    // Método llamado cuando el jugador entrega la manzana
    public void GiveApple()
    {
        hasGivenApple = true; // Actualiza el estado de la manzana
        CheckDoorStatus(); // Verifica el estado de la puerta
    }

    // Cambia el estado de la puerta según el estado de la manzana
    private void CheckDoorStatus()
    {
        if (hasGivenApple)
        {
            isDoorLocked = false; // Desbloquea la puerta
        }
    }
}
