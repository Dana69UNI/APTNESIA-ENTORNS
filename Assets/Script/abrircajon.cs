using UnityEngine;

public class abrircajon : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private GameObject objetoCorrecto; // El objeto que debe colocarse (por ejemplo, el disco)
    [SerializeField] private GameObject cajon; // El cajón que se abrirá
    [SerializeField] private Vector3 rotacionAbierta; // Rotación final del cajón al abrirse (en euler angles)
    [SerializeField] private float velocidadApertura = 2f; // Velocidad de apertura

    private bool cajonAbierto = false; // Para evitar que se abra múltiples veces
    private Quaternion rotacionInicial; // Rotación inicial del cajón
    private Quaternion rotacionFinal; // Rotación final del cajón

    private void Start()
    {
        if (cajon != null)
        {
            // Guardar la rotación inicial del cajón
            rotacionInicial = cajon.transform.rotation;

            // Calcular la rotación final del cajón a partir de los euler angles
            rotacionFinal = Quaternion.Euler(rotacionAbierta);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto colocado es el correcto
        if (other.gameObject == objetoCorrecto && !cajonAbierto)
        {
            cajonAbierto = true;
            StartCoroutine(AbrirCajon());
        }
    }

    private System.Collections.IEnumerator AbrirCajon()
    {
        float tiempo = 0;

        while (tiempo < 1f)
        {
            tiempo += Time.deltaTime * velocidadApertura;

            // Interpolación de la rotación
            cajon.transform.rotation = Quaternion.Lerp(rotacionInicial, rotacionFinal, tiempo);

            yield return null;
        }
    }
}
