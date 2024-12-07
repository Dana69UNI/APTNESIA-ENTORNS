using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using FMOD.Studio;

public class llave : MonoBehaviour
{
    public InputActionReference Interact;
    private bool isPlayerNear = false;
    private bool CanPick=false;
    private bool isSafeOpen=false;
    [SerializeField] abrirpuerta _puertaopen;
    [SerializeField] private EventInstance SpawnAmbient;


    private void Start()
    {
     gameObject.SetActive(false);
        SpawnAmbient = AudioManager.Instance.CreateEventInstanceObj(FMODEvents.instance.KeyAppear, gameObject.transform);
    }

    private void noPick()
    {
        CanPick = false;
    }
    private void pick()
    {
        CanPick = true;
    }

    public void safeToggle()
    {
        isSafeOpen = !isSafeOpen;
        gameObject.SetActive(true);
        SpawnAmbient.start();

    }
    private void pickable()
    {
        Debug.Log("pickable");
        if (Interact.action.IsPressed() && isPlayerNear && isSafeOpen) 
        {
            _puertaopen.DoorStatus();
            Destroy(gameObject);
        }
        if (Interact.action.IsPressed())
        {
            UnityEngine.Debug.Log("Lejos");
        }
    }

    private void Update()
    {
        if (CanPick)
        {
            pickable();
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {

            isPlayerNear = true;
            Debug.Log("aaa");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {

            isPlayerNear = false;
        }
    }

    private void OnDestroy()
    {
        SpawnAmbient.stop(STOP_MODE.ALLOWFADEOUT);
    }

}

