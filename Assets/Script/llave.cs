using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class llave : MonoBehaviour
{
    public InputActionReference Interact;
    private bool isPlayerNear = false;
    [SerializeField] abrirpuerta _puertaopen;

    private void Start()
    {
        interactiveSystem.pickFound += pickable;
    }

    private void pickable()
    {
        if (Interact.action.IsPressed() && isPlayerNear)
        {
            _puertaopen.DoorStatus();
            Destroy(gameObject);
        }
        if (Interact.action.IsPressed())
        {
            UnityEngine.Debug.Log("Lejos");
        }
    }

    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {

            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {

            isPlayerNear = false;
        }
    }
}

