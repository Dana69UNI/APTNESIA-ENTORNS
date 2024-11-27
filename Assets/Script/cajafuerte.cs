using UnityEngine;
using UnityEngine.UI;

public class cajafuerte : MonoBehaviour
{
    [Header("C�digo correcto")]
    [SerializeField] private string codigoCorrecto = "1234";

    [Header("Interfaz de usuario")]
    [SerializeField] private InputField inputField;
    [SerializeField] private GameObject panelCodigo; // El panel de entrada
    [SerializeField] private Text mensajeFeedback; // Para mensajes como "Correcto" o "Incorrecto"

    private bool estaAbierta = false;

    void Update()
    {
        // Detectar si el jugador presiona la tecla E cerca de la caja
        if (Input.GetKeyDown(KeyCode.E) && !estaAbierta)
        {
            panelCodigo.SetActive(true); // Mostrar el panel de entrada
        }
    }

    public void VerificarCodigo()
    {
        if (inputField.text == codigoCorrecto)
        {
            mensajeFeedback.text = "�C�digo correcto!";
            mensajeFeedback.color = Color.green;
            AbrirCaja();
        }
        else
        {
            mensajeFeedback.text = "C�digo incorrecto";
            mensajeFeedback.color = Color.red;
        }
    }

    private void AbrirCaja()
    {
        estaAbierta = true;
        panelCodigo.SetActive(false); // Ocultar el panel de entrada
        // Animaci�n o acci�n para abrir la caja
        transform.Rotate(0, 90, 0); // Ejemplo: rotar la caja 90 grados
    }
}

