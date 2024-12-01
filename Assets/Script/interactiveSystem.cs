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
    public static Action interFound; //creo una accion InterFound, esto lo que hace es enviar un aviso a todos los objetos que esten suscritos a ella así no hay que hacer rollos raros para interactuar entre diferentes cosas.
    public static Action interNotFound;
    public static Action pickNotFound;
    public static Action pickFound;
   

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
            pickFound?.Invoke(); //Aqui invocamos la accion para que todo el que este suscrito haga lo suyo.
        }
        else
        {
            pickNotFound?.Invoke();
        }
    }

    public void CheckInteractive() //checkinteractive es una funcion para ver que lo que hay delante del jugador tiene la Layer Interactive
    {
        RaycastHit hit; //Variable de cuando el raycast choca con un objeto
        Debug.Log("Funciono");
        if (Physics.Raycast(intRay.position, intRay.forward, //defines la posicion donde empieza (la posicion del empty interactiveRay), para donde va (forward), y que choque antes de la MaxDistance
            out hit,
            MaxDistance,
            Interactive))
        {
            //Debug.Log("Interactuable"); //si choca con algo y tiene la Layer Interactive pues empieza la funcion.
            interFound?.Invoke(); //Aqui invocamos la accion para que todo el que este suscrito haga lo suyo.
            hit.collider.SendMessage("CanGrab");
            
        }
      else
        {
            interNotFound?.Invoke();
            
            
        }
       
    }


}
