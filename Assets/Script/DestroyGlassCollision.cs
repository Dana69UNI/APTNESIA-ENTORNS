using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGlassCollision : MonoBehaviour
{

    [SerializeField] private EventInstance GlassShatter;

    private void Start()
    {
        GlassShatter = AudioManager.Instance.CreateEventInstanceObj(FMODEvents.instance.GlassShatter, gameObject.transform);
    }

    public int DestroyMagnitude =1;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > DestroyMagnitude)
        {
            GlassShatter.start();
            Destroy(gameObject);
        }
    }
}
