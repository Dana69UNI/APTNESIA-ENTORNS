using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveSystem : MonoBehaviour
{
    public Transform intRay;
    public Transform pickRay;
    public float MaxDistance = 0.7f;
    public LayerMask Interactive;
    public LayerMask Pickable;
    private uiInteractive _uiInteractive;
    public uiPickable _uiPickable;
    private GameObject lastPickable;
    private GameObject lastInteracted;
   

    private void Start()
    {
        _uiInteractive = gameObject.GetComponentInChildren<uiInteractive>();

    }

    private void Update()
    {
        CheckInteractive();
        CheckPickable();
    }

    private void CheckPickable()
    {
        RaycastHit Phit;
        if (Physics.Raycast(pickRay.position, pickRay.forward, //defines la posicion donde empieza (la posicion del empty interactiveRay), para donde va (forward), y que choque antes de la MaxDistance
            out Phit,
            MaxDistance,
            Pickable))
        {
            //Debug.Log("Interactuable"); //si choca con algo y tiene la Layer Interactive pues empieza la funcion.
            _uiPickable.Show();
            if (Phit.collider != null) // Asegúrate de que existe un collider
            {
                Phit.collider.SendMessage("pick");
                lastPickable = Phit.collider.gameObject;
            }
        }
        else
        {
            _uiPickable.Hide();
            if (lastPickable != null)
            {
                lastPickable.SendMessage("noPick");
            }
        }
    }

    public void CheckInteractive() //checkinteractive es una funcion para ver que lo que hay delante del jugador tiene la Layer Interactive
    {
        RaycastHit hit; //Variable de cuando el raycast choca con un objeto
     
        if (Physics.Raycast(intRay.position, intRay.forward, //defines la posicion donde empieza (la posicion del empty interactiveRay), para donde va (forward), y que choque antes de la MaxDistance
            out hit,
            MaxDistance,
            Interactive))
        {
            //Debug.Log("Interactuable"); //si choca con algo y tiene la Layer Interactive pues empieza la funcion.
            if (hit.collider != null) // Asegúrate de que existe un collider
            {
                hit.collider.SendMessage("CanGrab");
                _uiInteractive.Show();
            }
        }
      else
        {
            _uiInteractive.Hide();
        } 
    }
}
