using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiInteractive : MonoBehaviour
{
    
    void Awake()
    {
        gameObject.SetActive(false);
        interactiveSystem.interFound += Show; //se suscribe a la accion Interfound y si le llega el aviso hara la funcion Show()
        interactiveSystem.interNotFound += Hide;
       
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
