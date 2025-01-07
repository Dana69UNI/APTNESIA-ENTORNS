using UnityEngine;

public class CarlosAppleKey : MonoBehaviour
{
    public float detectionRadius = 5f;  // Radio de detecci�n para la manzana
    public GameObject keyPrefab;        // Prefab de la llave para que Carlos la suelte
    private Transform apple;            // Referencia a la manzana
    private bool hasApple = false;      // Indica si Carlos tiene la manzana

    private void Update()
    {
        if (hasApple) return; // Si ya tiene la manzana, no hace nada m�s

        CheckForAppleInRange(); // Detectar la manzana en el rango
    }

    // M�todo para detectar la manzana en el rango
    private void CheckForAppleInRange()
    {
        Collider[] objectsInRange = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider obj in objectsInRange)
        {
            if (obj.CompareTag("Apple"))
            {
                apple = obj.transform;
                PickUpApple(); // Recoge la manzana inmediatamente si est� dentro del rango
                break;
            }
        }
    }

    // M�todo para recoger la manzana
    private void PickUpApple()
    {
        hasApple = true;

        if (apple != null)
        {
            Destroy(apple.gameObject); // Elimina la manzana
        }

        DropKey(); // Carlos suelta la llave
        Debug.Log("Carlos ha recogido la manzana y ha soltado la llave.");
    }

    // M�todo para soltar la llave
    private void DropKey()
    {
        //if (keyPrefab != null)
        //{
        //    // Instancia la llave en la posici�n de Carlos
        //    Debug.Log("entro en el if");

        //    GameObject droppedKey = Instantiate(keyPrefab, transform.position, Quaternion.identity);

        //    // Aseg�rate de que la llave tenga un Rigidbody para que caiga
        //    Rigidbody keyRb = droppedKey.GetComponent<Rigidbody>();
        //    if (keyRb == null)
        //    {
        //        keyRb = droppedKey.AddComponent<Rigidbody>();
        //    }

        //    keyRb.useGravity = true; // Activar la gravedad para que caiga
        //}
        //else
        //{
            
            keyPrefab.gameObject.SetActive(true);
            Vector3 posicionCarlos = transform.position;
            keyPrefab.gameObject.transform.position = posicionCarlos - new Vector3(0,1,0) ;
        //}
    }

    private void OnDrawGizmosSelected()
    {
        // Visualizaci�n del rango de detecci�n en el editor
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}