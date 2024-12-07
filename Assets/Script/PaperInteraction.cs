using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaperInteraction : MonoBehaviour
{
    private bool isPlayerNear = false;  // Variable para detectar proximidad del jugador
    private bool isPaperOpen = false;  // Variable para saber si el Canvas está abierto
    private bool CanPick = false;

    public GameObject paperModel;      // Objeto del papel en la escena
    public GameObject paperUI;         // UI para mostrar el papel ampliado
    public InputActionReference Interact;

    void Start()
    {
        if (paperUI != null)
        {
            paperUI.SetActive(false); // Asegurarse de que el UI esté oculto al inicio
        }

    }

    private void noPick()
    {
        CanPick = false;
    }
    private void pick()
    {
        CanPick = true;
    }
    private void pickable()
    {
   
        // Detectar si el jugador presiona "E" cuando está cerca
        if (Interact.action.triggered && isPlayerNear)
        {
            TogglePaperUI();
            Debug.Log("Presionado");
        }
    }

    void Update()
    {
        if(CanPick)
        {
            pickable();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Detectar solo al jugador
        {
            isPlayerNear = true;
            Debug.Log("Presiona E para interactuar con el papel");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Saliste de la zona del papel");

            // Si el jugador se aleja y el papel estaba abierto, lo cerramos
            if (isPaperOpen)
            {
                TogglePaperUI();
            }
        }
    }

    void TogglePaperUI()
    {
        if (paperUI != null)
        {
            isPaperOpen = !isPaperOpen; // Alterna el estado de apertura
            paperUI.SetActive(isPaperOpen); // Activa o desactiva el Canvas
            Debug.Log(isPaperOpen ? "Mostrando el papel" : "Ocultando el papel");
        }
    }
}

