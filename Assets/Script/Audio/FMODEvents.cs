using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class FMODEvents : MonoBehaviour
{
   

    public static FMODEvents instance { get; private set; }

    [field: Header("ResipiracionSFX")]
    [field: SerializeField] public EventReference Respira { get; private set; }

    [field: Header("ResipiracionAgitadaSFX")]
    [field: SerializeField] public EventReference RespiraAgit { get; private set; }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
          
        }
        else
        {
           
        }
    }


}
