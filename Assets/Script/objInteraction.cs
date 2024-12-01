using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class objInteraction : MonoBehaviour
{
    
    public InputActionReference Grab;
    public InputActionReference Throw;
    public Transform intChar;
    private float forceStrength = 150f;
    //private float dragStrength = 28f;
    //private float aDragStrength = 20f;
    private Rigidbody rb;
    bool grabbable = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        interactiveSystem.interNotFound += NoGrab;
    }
    private void FixedUpdate()
    {
        if (grabbable)
        {
            if (Grab.action.IsPressed())
            {

                //Vector3 direction = intChar.position - transform.position;
                //rb.drag = dragStrength;
                //rb.angularDrag = aDragStrength;
                //rb.useGravity = false;
                //rb.AddForce(direction.normalized * forceStrength * Time.deltaTime, ForceMode.VelocityChange);
                gameObject.transform.position = intChar.transform.position;

                if(Throw.action.IsPressed())
                {
                    NoGrab();
                    rb.AddForce(intChar.forward * forceStrength * Time.deltaTime, ForceMode.VelocityChange);
                    NoGrab();
                }
            }
            else
            {
                //rb.drag = 0f;
                //rb.angularDrag = 0f;
                //rb.useGravity = true;
            }
        }
        else
        {
            //rb.drag = 0f;
            //rb.angularDrag = 0f;
            //rb.useGravity = true;
        }

    }
    private void CanGrab()
    {
       grabbable = true;
    }
    private void NoGrab()
    {
        grabbable = false;
    }
    
}
