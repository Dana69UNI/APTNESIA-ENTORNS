using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llave : MonoBehaviour
{
    [SerializeField] abrirpuerta _puertaopen;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _puertaopen.DoorStatus();
            Destroy(gameObject);

        }
    }
}
