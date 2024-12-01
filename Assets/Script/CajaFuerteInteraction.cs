using UnityEngine;

public class CajaFuerteInteraction : MonoBehaviour
{
    public GameObject UICaja; // Asigna el panel de la UI en el inspector.
    public float distanciaInteraccion = 3f; // Distancia para interactuar.
    private GameObject playerScripts;
    private Transform jugador; // Referencia al jugador.

    void Start()
    {
        playerScripts = GameObject.FindWithTag("Player");
        jugador = GameObject.FindWithTag("Player").transform; // Asegúrate de que tu jugador tenga la etiqueta "Player".
    }

    void Update()
    {
    
        // Calcula la distancia entre el jugador y la caja fuerte.
        if (Vector3.Distance(jugador.position, transform.position) < distanciaInteraccion)
        {

            if (Input.GetKeyDown(KeyCode.E)) // Tecla para interactuar.
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                playerScripts.GetComponent<camControl>().enabled = false;
                UICaja.SetActive(true); // Muestra el panel.
                Time.timeScale = 0; // Pausa el juego.
            }
        }
    }

    public void CerrarPanel()
    {
        UICaja.SetActive(false);
        playerScripts.GetComponent<camControl>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1; // Reanuda el juego.
    }
}
