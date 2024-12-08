using UnityEngine;

public class GroundCollisionHandler : MonoBehaviour
{
    private bool isOnGround = false; // Si el objeto está en el suelo
    public int karmaPenalty = 999;     // Puntos de karma que se restan

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isOnGround) //Se activa si tiene el tag "ground"
        {
            isOnGround = true; //estas 3 lineas es para reducir karma 
            KarmaManager.Instance.RemoveKarma(karmaPenalty);
            Debug.Log("sededujokarma");
        }
    }

    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Ground") && isOnGround)
        {
            isOnGround = false; //estas 3 lineas es para aumentar karma 
            KarmaManager.Instance.AddKarma(karmaPenalty);
        }
    }
}
