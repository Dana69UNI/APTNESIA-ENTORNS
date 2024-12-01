using UnityEngine;
using TMPro; // Importante: Esto permite usar TextMeshPro.

public class CodigoVerificacion : MonoBehaviour
{
    public TMP_InputField input1; // Campos de entrada de TextMeshPro.
    public TMP_InputField input2;
    public TMP_InputField input3;
    public CajaFuerteInteraction cajaFuerteInt;
    public string codigoCorrecto = "123"; // Código correcto para abrir la caja fuerte.
    public GameObject cajaFuerte; // Asigna la caja fuerte en el inspector.

    public void VerificarCodigo()
    {
        // Concatena los valores ingresados.
        string codigoIngresado = input1.text + input2.text + input3.text;

        if (codigoIngresado == codigoCorrecto)
        {
            AbrirCaja();
        }
        else
        {
            Debug.Log("Código incorrecto"); // Mensaje de error en la consola.
        }
    }

    void AbrirCaja()
    {
        cajaFuerteInt.CerrarPanel();
        Debug.Log("¡Caja Abierta!"); // Mensaje en la consola.
        Destroy(cajaFuerte); // Cambia esto por una animación si tienes una.
    }
}
