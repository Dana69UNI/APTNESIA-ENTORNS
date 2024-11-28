using UnityEngine;

public class ActivarAnimacionLuz : MonoBehaviour
{
    public Animator animadorLuz;  // Referencia al Animator de la luz
    private bool luzActivada = false; // Para asegurarnos que solo se activa una vez

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es el jugador y si la luz no ha sido activada previamente
        if (other.CompareTag("Player") && !luzActivada)
        {
            animadorLuz.SetTrigger("encender_luz");  // Activa el trigger de la animación
            luzActivada = true;  // Marca que la luz ya ha sido activada
        }
    }
}
