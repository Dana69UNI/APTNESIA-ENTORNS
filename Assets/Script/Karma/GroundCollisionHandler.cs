using UnityEngine;

public class GroundCollisionHandler : MonoBehaviour
{
    private bool isOnGround = false; // Si el objeto está en el suelo
    public int karmaPenalty = 5;     // Puntos de karma que se restan

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isOnGround) //Se activa si tiene el tag "ground" (el suelo) (por si acaso)
        {
            isOnGround = true; //estas 3 lineas es para reducir karma 
            KarmaManager.Instance.RemoveKarma(karmaPenalty);
            Debug.Log($"{gameObject.name} cayó al suelo. Karma reducido."); //esto es para comprobar, quitar el texto cuando acabe las pruebas
        }
    }

    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Ground") && isOnGround)
        {
            isOnGround = false; //estas 3 lineas es para aumentar karma 
            KarmaManager.Instance.AddKarma(karmaPenalty);
            Debug.Log($"{gameObject.name} fue recogido del suelo. Karma restaurado.");//esto es para comprobar, quitar el texto cuando acabe las pruebas
        }
    }
}
