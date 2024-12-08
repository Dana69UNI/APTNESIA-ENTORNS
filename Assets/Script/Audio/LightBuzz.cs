using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class LightBuzz : MonoBehaviour
{
    [SerializeField] private EventInstance Buzz;

    private void Start()
    {
        Buzz = AudioManager.Instance.CreateEventInstanceObj(FMODEvents.instance.LightSound, gameObject.transform);
        Buzz.start();
    }

    private void OnDestroy()
    {
        Buzz.stop(STOP_MODE.IMMEDIATE);
    }

}
