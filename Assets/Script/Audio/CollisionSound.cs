using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class CollisionSound : MonoBehaviour
{
    [SerializeField] private EventInstance ObjectHit;

    private void Start()
    {
        ObjectHit = AudioManager.Instance.CreateEventInstanceObj(FMODEvents.instance.ObjHit, gameObject.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 2)
        {
            ObjectHit.start();
        }
    }

}
