using UnityEngine;
using UnityEngine.SceneManagement;

public class personaje : MonoBehaviour
{
    private static bool personajeExistente = false;

    public Transform puntoDeInicio; // Referencia al objeto vacío que será el punto de inicio

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

    private void OnLevelWasLoaded(int level)
    {
        // Mover al personaje al punto de inicio de la nueva escena
        if (puntoDeInicio != null)
        {
            transform.position = puntoDeInicio.position;
            transform.rotation = puntoDeInicio.rotation; // Si también quieres ajustar la rotación
        }
    }
}
