using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
public class ActivarLuzTerror : MonoBehaviour
{
    public Animator Luz;

    [SerializeField] private EventInstance Flick;

    private void Start()
    {
        Flick = AudioManager.Instance.CreateEventInstanceObj(FMODEvents.instance.LightFlickr, gameObject.transform);
        
    }

   
    private void OnTriggerEnter(Collider other)
    {
        Flick.start();
        Luz.Play("parpadeo_luz");
        
    }
}