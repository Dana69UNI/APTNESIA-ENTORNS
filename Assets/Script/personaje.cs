using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class personaje : MonoBehaviour
{
    private static bool personajeExistente = false;

    private GameObject puntoDeInicio; // Referencia al objeto vac�o que ser� el punto de inicio
    private Transform spawnPoint;

    private void Start()
    {
       

    }
    private void Awake()
    {
        // Verificamos si ya existe el personaje

        if (personajeExistente)
        {
            Destroy(gameObject); // Si ya existe, destruimos el objeto duplicado
        }
        else
        {
            personajeExistente = true; // Si es el primero, lo marcamos como existente
            DontDestroyOnLoad(gameObject); // Lo mantenemos entre escenas
        }
    }

    private void OnEnable()
    {
        // Suscribir al evento sceneLoaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Cancelar la suscripci�n al evento sceneLoaded
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        puntoDeInicio = GameObject.FindWithTag("Respawn");
        spawnPoint = puntoDeInicio.transform;
        spawnCharacter();
        //if (puntoDeInicio != null)
        //{
        //    transform.position = puntoDeInicio.position;
        //    transform.rotation = puntoDeInicio.rotation; // Si tambi�n quieres ajustar la rotaci�n
        //}
    }

    private void spawnCharacter()
    {
        gameObject.transform.position = spawnPoint.position;
    }
}

