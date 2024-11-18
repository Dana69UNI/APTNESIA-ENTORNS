using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class characterMovement : MonoBehaviour
{
    public Rigidbody rb; //Coge el rigidbody del personaje
    private float moveSpeed = 5.0f; //movimiento velocidad
    public InputActionReference move; //VER INPUTS, lo necesitamos para que lea los valores del WASD o del Stick del mando para mover al personaje
    private Vector2 _moveDirection; //el vector 2 donde guardamos los valores

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector2>();
        OnMove();
    }

    private void OnMove()
    {
        rb.velocity = new Vector3(_moveDirection.x * moveSpeed, rb.velocity.y, _moveDirection.y * moveSpeed);
    }
}
