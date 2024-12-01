using UnityEngine;

public class CajaFuerteInteraction : MonoBehaviour
{
    public GameObject panelCodigo; // Asigna el panel de la UI en el inspector.
    public float distanciaInteraccion = 3f; // Distancia para interactuar.

    private Transform jugador; // Referencia al jugador.

    void Start()
    {
        jugador = GameObject.FindWithTag("Player").transform; // Asegúrate de que tu jugador tenga la etiqueta "Player".
    }

    void Update()
    {
        // Calcula la distancia entre el jugador y la caja fuerte.
        if (Vector3.Distance(jugador.position, transform.position) < distanciaInteraccion)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Tecla para interactuar.
            {
                panelCodigo.SetActive(true); // Muestra el panel.
                Time.timeScale = 0; // Pausa el juego.
            }
        }
    }

    public void CerrarPanel()
    {
        panelCodigo.SetActive(false);
        Time.timeScale = 1; // Reanuda el juego.
    }
}
