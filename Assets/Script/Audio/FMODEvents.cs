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

    [field: Header("Musica")]
    [field: SerializeField] public EventReference Musica { get; private set; }

    [field: Header("ObjHit")]
    [field: SerializeField] public EventReference ObjHit { get; private set; }

    [field: Header("GlassShatter")]
    [field: SerializeField] public EventReference GlassShatter { get; private set; }

    [field: Header("PlayerStep")]
    [field: SerializeField] public EventReference PlayerStep { get; private set; }

    [field: Header("AmbientSound")]
    [field: SerializeField] public EventReference AmbientSound { get; private set; }

    [field: Header("ClockTick")]
    [field: SerializeField] public EventReference ClockTick { get; private set; }

    [field: Header("KeyAppear")]
    [field: SerializeField] public EventReference KeyAppear { get; private set; }

    [field: Header("LightSound")]
    [field: SerializeField] public EventReference LightSound { get; private set; }

    [field: Header("LightFlickr")]
    [field: SerializeField] public EventReference LightFlickr { get; private set; }

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
