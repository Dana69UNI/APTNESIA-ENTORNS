using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class characterMovement : MonoBehaviour
{
    private Rigidbody rb; //Coge el rigidbody del personaje
    private float moveSpeed = 20.0f; //la velocidad
    private float objDrag = 5f; //drag para que el rb no se resbale
    public InputActionReference move; //VER INPUTS, lo necesitamos para que lea los valores del WASD o del Stick del mando para mover al personaje
    private Vector2 inputDirection; //el vector 2 donde guardamos los valores
    Vector3 _moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.drag = objDrag;
    }

    // Update is called once per frame
    void Update()
    {

        inputManage();
      
    }

   void FixedUpdate()
    {
        OnMove();
    }

    private void inputManage()
    {
       inputDirection = move.action.ReadValue<Vector2>();
        _moveDirection = transform.forward * inputDirection.y + transform.right * inputDirection.x; //Transform.forward y right para que el movimiento sea acorde a los ejes del personaje. 
    }
    private void OnMove()
    {
     
        rb.AddForce(_moveDirection.normalized * moveSpeed, ForceMode.Acceleration); //en vez de usar rb.velocity como la ultima vez, usamos addforce, solo porque supuestamente lo otro puede llevar a problemas
    //el .normalized sirve para que la velocidad en diagonal sea la misma que para cualquier lado, (normaliza el vector vaya).
    }
}
