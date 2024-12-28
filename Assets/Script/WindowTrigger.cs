using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    public GameObject applePrefab; // Prefab de la manzana
    public Transform spawnVentana;  // Punto de aparición de la manzana
    public float throwForce = 10f; // Fuerza del lanzamiento

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Book")) // Verifica si el objeto es el libro
        {
            ThrowApple();
        }
    }

    private void ThrowApple()
    {
        // Instancia la manzana en el punto de spawn
        GameObject apple = Instantiate(applePrefab, spawnVentana.position, spawnVentana.rotation);

        // Añade fuerza a la manzana para lanzarla
        Rigidbody rb = apple.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(-spawnVentana.forward * throwForce, ForceMode.Impulse);
        }
    }
}
