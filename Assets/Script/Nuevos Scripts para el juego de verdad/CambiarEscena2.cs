using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena2 : MonoBehaviour
{
    private GameObject Character;
    private GameObject Inicio;

    private void Start()
    {
        Character = GameObject.FindWithTag("Player");
        Inicio = GameObject.FindWithTag("PuntoDeInicio");
    }
    private void OnTriggerEnter(Collider other)
    {
        Character.transform.position = Inicio.transform.position;
        SceneManager.LoadScene(2);
    }
}