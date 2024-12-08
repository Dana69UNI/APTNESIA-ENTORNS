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
           
            uiPickable = GetComponentInChildren<uiPickable>(); 
            
        }

        if (uiInteractive == null)
        {
            uiInteractive = GetComponentInChildren<uiInteractive>();
           
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

