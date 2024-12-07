using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGlassCollision : MonoBehaviour
{
    public int DestroyMagnitude =1;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > DestroyMagnitude)
        {
            Destroy(gameObject);
        }
    }
}
