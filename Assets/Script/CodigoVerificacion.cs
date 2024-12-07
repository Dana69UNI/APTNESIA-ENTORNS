using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting; // Importante: Esto permite usar TextMeshPro.

public class CodigoVerificacion : MonoBehaviour
{
    public CajaFuerteInteraction cajaFuerteInt;
    public string codigoCorrecto = "123"; // Código correcto para abrir la caja fuerte.
    private GameObject cajaFuerte; // Asigna la caja fuerte en el inspector.
    private string codigoIngresado;
    public TMP_Text codigoEscrito;
    [SerializeField] llave _llave;
    [SerializeField] CajaFuerteInteraction _cajaFuerteInteraccion;

    private void Start()
    {
        cajaFuerte = GameObject.Find("CajaFuerte");
    }
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
        _llave.safeToggle();
        _cajaFuerteInteraccion.safeToggle();
        Debug.Log("¡Caja Abierta!"); // Mensaje en la consola.
        Destroy(cajaFuerte); // Cambia esto por una animación si tienes una.
    }

    public void BotonPress(int number)
    {
        Debug.Log("pulsado");
        codigoIngresado += number.ToString();
        codigoEscrito.text = codigoIngresado;
    }

    IEnumerator EsperaIncorrecto()
    {
        codigoEscrito.color = Color.red;
        codigoEscrito.text = "Incorrecto";
        yield return new WaitForSeconds(1);
       
        codigoEscrito.color = Color.white;
        codigoEscrito.text = null;
        codigoIngresado = null;
        
    }
}
