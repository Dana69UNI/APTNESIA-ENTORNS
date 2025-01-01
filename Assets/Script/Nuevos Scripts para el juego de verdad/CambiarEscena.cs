using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    private GameObject Character; // Referencia al personaje
    private GameObject PuntoDeInicio; // Referencia al punto de inicio

    // Nombres de las escenas a cargar seg�n el karma
    [SerializeField] private string casa1SceneName = "casa1"; // Karma neutral
    [SerializeField] private string casa2SceneName = "casa2"; // Karma positivo
    [SerializeField] private string casa3SceneName = "casa3"; // Karma negativo

    private void Start()
    {
        // Buscar al personaje y al punto de inicio usando los tags
        Character = GameObject.FindWithTag("Player");
        PuntoDeInicio = GameObject.FindWithTag("PuntoDeInicio");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que activa el trigger es el personaje
        if (other.CompareTag("Player"))
        {
            // Verificar si el KarmaManager est� presente
            if (KarmaManager.Instance == null)
            {
                Debug.LogError("KarmaManager.Instance es null. �Est� KarmaManager en la escena?");
                return;
            }

            // Obtener el karma actual
            int karma = KarmaManager.Instance.GetKarma();

            // Cambiar de escena seg�n el karma
            if (karma <= -10)
            {
                SceneManager.LoadScene(casa3SceneName); // Escena dist�pica
            }
            else if (karma >= 10)
            {
                SceneManager.LoadScene(casa2SceneName); // Escena ut�pica
            }
            else
            {
                SceneManager.LoadScene(casa1SceneName); // Escena neutral
            }

            // Reposicionar al personaje en el punto de inicio
            if (Character != null && PuntoDeInicio != null)
            {
                Character.transform.position = PuntoDeInicio.transform.position;
            }
            else
            {
                Debug.LogWarning("No se encontr� el Character o el PuntoDeInicio.");
            }
        }
    }
}
