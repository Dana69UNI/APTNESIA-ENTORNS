using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class ClockTickingSound : MonoBehaviour
{
    [SerializeField] private EventInstance Tick;

    private void Start()
    {
        Tick = AudioManager.Instance.CreateEventInstanceObj(FMODEvents.instance.ClockTick, gameObject.transform);
        Tick.start();
    }

    private void OnDestroy()
    {
        Tick.stop(STOP_MODE.IMMEDIATE);
    }


}