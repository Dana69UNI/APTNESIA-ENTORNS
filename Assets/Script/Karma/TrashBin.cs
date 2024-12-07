using UnityEngine;

public class TrashBin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash")) // Verifica si el objeto es basura
        {
            Debug.Log("¡Basura colocada correctamente!");

            // Encuentra el KarmaManager y aumenta el karma
            FindObjectOfType<KarmaManager>().AddKarma(10);

            // Destruye la basura después de colocarla
            Destroy(other.gameObject);
        }
    }
}
