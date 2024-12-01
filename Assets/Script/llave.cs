using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class llave : MonoBehaviour
{
    public InputActionReference Interact;
    [SerializeField] abrirpuerta _puertaopen;

    private void Start()
    {
        interactiveSystem.pickFound += pickable;
    }

    private void pickable()
    {
        if (Interact.action.IsPressed())
        {
            _puertaopen.DoorStatus();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            //_puertaopen.DoorStatus();
            //Destroy(gameObject);

        }
    }
}
