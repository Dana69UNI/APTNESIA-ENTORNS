using UnityEngine;

public class abrircajon : MonoBehaviour
{
    [Header("Configuraci�n")]
    [SerializeField] private GameObject objetoCorrecto; // El objeto que debe colocarse (por ejemplo, el disco)
    [SerializeField] private GameObject cajon; // El caj�n que se abrir�
    [SerializeField] private Vector3 rotacionAbierta; // Rotaci�n final del caj�n al abrirse (en euler angles)
    [SerializeField] private float velocidadApertura = 2f; // Velocidad de apertura

    private bool cajonAbierto = false; // Para evitar que se abra m�ltiples veces
    private Quaternion rotacionInicial; // Rotaci�n inicial del caj�n
    private Quaternion rotacionFinal; // Rotaci�n final del caj�n

    private void Start()
    {
        if (cajon != null)
        {
            // Guardar la rotaci�n inicial del caj�n
            rotacionInicial = cajon.transform.rotation;

            // Calcular la rotaci�n final del caj�n a partir de los euler angles
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

            // Interpolaci�n de la rotaci�n
            cajon.transform.rotation = Quaternion.Lerp(rotacionInicial, rotacionFinal, tiempo);

            yield return null;
        }
    }
}
