using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiPickable : MonoBehaviour
{

    void Start()
    {
        gameObject.SetActive(false);
        interactiveSystem.pickFound += Show; //se suscribe a la accion Interfound y si le llega el aviso hara la funcion Show()
        interactiveSystem.pickNotFound += Hide;

    }


    public void Show()
    {

        gameObject.SetActive(true);
    }

    public void Hide()
    {

        gameObject.SetActive(false);
    }
}