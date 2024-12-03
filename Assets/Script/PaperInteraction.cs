//using UnityEngine;

//public class PaperInteraction : MonoBehaviour
//{
//    private bool isPlayerNear = false;  // Variable para detectar proximidad del jugador
//    public GameObject paperModel;      // Objeto del papel en la escena
//    public GameObject paperUI;         // UI para mostrar el papel ampliado

//    void Start()
//    {
//        if (paperUI != null)
//        {
//            paperUI.SetActive(false); // Oculta el UI al inicio
//        }
//    }

//    void Update()
//    {
//        // Detectar si el jugador presiona "E" cuando está cerca
//        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
//        {
//            ShowPaper();
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player")) // Asegurarse de que el objeto tenga el tag "Player"
//        {
//            isPlayerNear = true;
//            Debug.Log("Presiona E para recoger el papel");
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            isPlayerNear = false;
//        }
//    }

//    void ShowPaper()
//    {
//        if (paperModel != null)
//        {
//            paperModel.SetActive(false); // Oculta el papel en la escena
//        }
//        if (paperUI != null)
//        {
//            paperUI.SetActive(true);     // Muestra el UI del papel ampliado
//        }
//        Debug.Log("Mostrando el papel en la UI");
//    }
//}

using UnityEngine;

public class PaperInteraction : MonoBehaviour
{
    private bool isPlayerNear = false;  // Variable para detectar proximidad del jugador
    private bool isPaperOpen = false;  // Variable para saber si el Canvas está abierto
    public GameObject paperModel;      // Objeto del papel en la escena
    public GameObject paperUI;         // UI para mostrar el papel ampliado

    void Start()
    {
        if (paperUI != null)
        {
            paperUI.SetActive(false); // Asegurarse de que el UI esté oculto al inicio
        }
    }

    void Update()
    {
        // Detectar si el jugador presiona "E" cuando está cerca
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            TogglePaperUI();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Detectar solo al jugador
        {
            isPlayerNear = true;
            Debug.Log("Presiona E para interactuar con el papel");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Saliste de la zona del papel");
        }
    }

    void TogglePaperUI()
    {
        if (paperUI != null)
        {
            isPaperOpen = !isPaperOpen; // Alterna el estado de apertura
            paperUI.SetActive(isPaperOpen); // Activa o desactiva el Canvas
            Debug.Log(isPaperOpen ? "Mostrando el papel" : "Ocultando el papel");
        }
    }
}
