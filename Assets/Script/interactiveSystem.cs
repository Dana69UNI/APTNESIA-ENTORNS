using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactiveSystem : MonoBehaviour
{
    public Transform intRay;
    private float MaxDistance = 10f;
    public LayerMask Interactive;
    public static Action interFound; //creo una accion InterFound, esto lo que hace es enviar un aviso a todos los objetos que esten suscritos a ella así no hay que hacer rollos raros para interactuar entre diferentes cosas.
    public static Action interNotFound;
   

    private void Update()
    {
        CheckInteractive();
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
            interFound?.Invoke(); //Aqui invocamos la accion para que todo el que este suscrito haga lo suyo.
            hit.collider.SendMessage("CanGrab");
            
        }
      else
        {
            interNotFound?.Invoke();
            
            
        }
    }


}
