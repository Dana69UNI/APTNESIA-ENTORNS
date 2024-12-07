using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiInteractive : MonoBehaviour
{
    
    void Start()
    {
        gameObject.SetActive(false);
       

    }

    public void Show()
    {
       
        gameObject.SetActive(true);
    }

    public void Hide()
    {
       
        gameObject.SetActive(false);
    }
}
