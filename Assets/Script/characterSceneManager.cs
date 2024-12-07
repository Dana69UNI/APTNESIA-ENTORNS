using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterSceneManager : MonoBehaviour
{
    private uiInteractive uiInteractive;
    private uiPickable uiPickable;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Busca el componente en los hijos al iniciar
        if (uiPickable == null)
        {
            uiPickable = GetComponentInChildren<uiPickable>();
        }
            
    

        // Busca el componente en los hijos al iniciar
        if (uiInteractive == null)
        {
            uiInteractive = GetComponentInChildren<uiInteractive>();
        }
            
    }



    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (uiPickable == null)
        {
            Debug.Log(" llegué.");
            uiPickable = GetComponentInChildren<uiPickable>(); 
            Debug.Log("uiPickable ha sido reinicializado.");
        }

        if (uiInteractive == null)
        {
            uiInteractive = GetComponentInChildren<uiInteractive>();
            Debug.Log("uiInteractive ha sido reinicializado.");
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

