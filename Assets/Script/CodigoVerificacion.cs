using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting; // Importante: Esto permite usar TextMeshPro.

public class CodigoVerificacion : MonoBehaviour
{
    public CajaFuerteInteraction cajaFuerteInt;
    public string codigoCorrecto = "123"; // Código correcto para abrir la caja fuerte.
    public GameObject cajaFuerte; // Asigna la caja fuerte en el inspector.
    private string codigoIngresado;
    public TMP_Text codigoEscrito;
    public void VerificarCodigo()
    {
        // Concatena los valores ingresados.
        

        if (codigoIngresado == codigoCorrecto)
        {
            AbrirCaja();
        }
        else
        {
            Debug.Log("Código incorrecto"); // Mensaje de error en la consola.
            
            StartCoroutine(EsperaIncorrecto());
            
        }   
    }

    void AbrirCaja()
    {
        cajaFuerteInt.CerrarPanel();
        Debug.Log("¡Caja Abierta!"); // Mensaje en la consola.
        Destroy(cajaFuerte); // Cambia esto por una animación si tienes una.
    }

    public void BotonPress(int number)
    {
        codigoIngresado += number.ToString();
        codigoEscrito.text = codigoIngresado;
    }

    IEnumerator EsperaIncorrecto()
    {
        codigoEscrito.color = Color.red;
        codigoEscrito.text = "Incorrecto";
        yield return new WaitForSeconds(1);
        Debug.Log("llego");
        codigoEscrito.color = Color.white;
        codigoEscrito.text = null;
        codigoIngresado = null;
        
    }
}
