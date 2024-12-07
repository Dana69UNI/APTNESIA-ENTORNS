using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiPickable : MonoBehaviour
{
   
    void Start()
    {
        gameObject.SetActive(false);
     
    
    }

    private void OnDestroy()
    {
   
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