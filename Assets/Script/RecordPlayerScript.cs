using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayerScript : MonoBehaviour
{
    [SerializeField] private EventInstance Musica;
    [SerializeField] private llave _llave;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Record"))
        {
            Destroy(collision.collider.gameObject);
            _llave.safeToggle();
        }
    }
}
