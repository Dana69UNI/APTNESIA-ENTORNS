using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class objInteraction : MonoBehaviour
{
    
    public InputActionReference Grab;
    public Transform intChar;
    private float forceStrength = 28f;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void CanGrab()
    {
        if(Grab.action.IsPressed())
        {

            Vector3 direction = intChar.position - transform.position;
            rb.AddForce(direction.normalized * forceStrength * Time.deltaTime, ForceMode.VelocityChange);

        }
    }
    
}
