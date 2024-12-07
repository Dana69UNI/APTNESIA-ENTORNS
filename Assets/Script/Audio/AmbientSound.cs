using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class AmbientSound : MonoBehaviour
{
    [SerializeField] private EventInstance Ambiente;

    private void Start()
    {
        Ambiente = AudioManager.Instance.CreateEventInstancePlayer(FMODEvents.instance.AmbientSound);
        Ambiente.start();
    }

    private void Awake()
    {
      
    }
   

}
