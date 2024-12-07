using UnityEngine;
using UnityEngine.InputSystem;

public class CajaFuerteInteraction : MonoBehaviour
{
    public GameObject UICaja; // UICaja es un Empty que tiene el panel y los botones, el canvas tiene que estar SIEMPRE activo, o almenos mejor si lo esta.
    public float distanciaInteraccion = 3f; // Distancia para interactuar.
    private GameObject playerScripts;
    private Transform jugador; // Referencia al jugador.
    public InputActionReference interact;
    bool safeIsOpen = false;

    void Start()
    {
        playerScripts = GameObject.FindWithTag("Player");
        jugador = GameObject.FindWithTag("Player").transform; // Asegúrate de que tu jugador tenga la etiqueta "Player".
    }

    void Update()
    {
        if (!safeIsOpen)
        {
            // Calcula la distancia entre el jugador y la caja fuerte.
            if (Vector3.Distance(jugador.position, transform.position) < distanciaInteraccion)
            {

                if (interact.action.IsPressed()) // Tecla para interactuar.
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    playerScripts.GetComponent<camControl>().enabled = false;
                    UICaja.SetActive(true); // Muestra el panel.

                }

            }
            else
            {
                CerrarPanel();
            }
        }
    }
    public void CerrarPanel()
    {
        UICaja.SetActive(false);
        playerScripts.GetComponent<camControl>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       
    }

    public void safeToggle()
    {
        safeIsOpen = !safeIsOpen;
           
    }
}
