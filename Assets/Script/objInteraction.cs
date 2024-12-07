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
    private Transform intChar;
    private Rigidbody _emptyRb;
    private Rigidbody rb;
    [SerializeField] private float grabSpring = 100f;  // Adjust grab strength values / SpringJoint values
    [SerializeField] private float grabDamper = 4.5f; // Adjust grab strength values / SpringJoint values
    [SerializeField] private float throwForce = 11.0f;
    bool grabbable = false;
    private bool isGrabbed;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        intChar = GameObject.Find("interactTransform").transform;
        _emptyRb = GameObject.Find("interactTransform").GetComponent<Rigidbody>();
        _emptyRb.isKinematic = true;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

    }
    private void FixedUpdate()
    {
      


    }

    private void Update()
    {
        if (grabbable)
        {
            if (Grab.action.IsPressed())
            {
                if(rb.velocity.magnitude < 0.8f)
                {
                    isGrabbed = true;
                    ApplySpringConstraint();
                    if(rb.CompareTag("Door"))
                    {
                        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                        
                    }
                    else
                    {
                        rb.freezeRotation = true;
                    }
                    
                }
                
            }
            else
            {
                ResetShooting();
            }

        }

        if(isGrabbed)
        {
            if (Throw.action.triggered)
            {
                ThrowObject();
            }
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

    private void ApplySpringConstraint()
    {

        if (_emptyRb && rb)
        {
            SpringJoint spring = rb.gameObject.GetComponent<SpringJoint>();
            if (!spring)
            {
                spring = rb.gameObject.AddComponent<SpringJoint>();
                spring.autoConfigureConnectedAnchor = false;
                spring.connectedBody = _emptyRb;
                spring.connectedAnchor = Vector3.zero;  
                spring.anchor = Vector3.zero;
                spring.spring = grabSpring;
                spring.damper = grabDamper;

                spring.massScale = 1f;
                spring.minDistance = 0.01f;
                spring.maxDistance = 0.2f;

            }
        }
    }

    private void ThrowObject()
    {
        ResetShooting();
        Vector3 throwDirection = intChar.transform.forward;
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        

    }

    private void ResetShooting()
    {
        NoGrab();
        isGrabbed = false;
        if (rb.CompareTag("Door"))
        {

        }
        else
        {
            rb.freezeRotation = false;
        }
            
        if (rb)
        {

            Destroy(rb.GetComponent<SpringJoint>());
        }

    }
}



//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.InputSystem;


//public class objInteraction : MonoBehaviour
//{

//    public InputActionReference Grab;
//    public InputActionReference Throw;
//    public Transform intChar;
//    private float forceStrength = 150f;
//    //private float dragStrength = 28f;
//    //private float aDragStrength = 20f;
//    private Rigidbody rb;
//    bool grabbable = false;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        interactiveSystem.interNotFound += NoGrab;
//    }
//    private void FixedUpdate()
//    {
//        if (grabbable)
//        {
//            if (Grab.action.IsPressed())
//            {

//                //Vector3 direction = intChar.position - transform.position;
//                //rb.drag = dragStrength;
//                //rb.angularDrag = aDragStrength;
//                //rb.useGravity = false;
//                //rb.AddForce(direction.normalized * forceStrength * Time.deltaTime, ForceMode.VelocityChange);
//                gameObject.transform.position = intChar.transform.position;

//                if(Throw.action.IsPressed())
//                {
//                    NoGrab();
//                    rb.AddForce(intChar.forward * forceStrength * Time.deltaTime, ForceMode.VelocityChange);
//                    NoGrab();
//                }
//            }
//            else
//            {
//                //rb.drag = 0f;
//                //rb.angularDrag = 0f;
//                //rb.useGravity = true;
//            }
//        }
//        else
//        {
//            //rb.drag = 0f;
//            //rb.angularDrag = 0f;
//            //rb.useGravity = true;

//        }

//    }
//    private void CanGrab()
//    {
//       grabbable = true;
//    }
//    private void NoGrab()
//    {
//        grabbable = false;
//    }

//}
