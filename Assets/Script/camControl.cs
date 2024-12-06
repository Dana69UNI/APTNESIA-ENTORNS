using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class camControl : MonoBehaviour
{
    Camera cam;
    public InputActionReference look; //Coger los inputs del apartado LOOK de nuestro playerInput
    private Vector2 inputDirection; //vector para guardar los inputs
    private float sensx = 200f; //sensibilidad del raton horizontal
    private float sensy = 80f; //sensibilidad del raton vertical

    float mouseX; //donde guardaremos el input solo de x
    float mouseY;//donde guardamos el input solo de y

    float mult = 0.01f; //multiplicador

    float rotationX; //Esta variable sera para rotar la camara en x
    float rotationY;//esta variable sera para rotar al personaje en y, y como la camara es hija del personaje tmb rotara :)

    private void Start()
    {
        cam = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        MyInput();
        cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0); //rotar la camara en x
        transform.localRotation = Quaternion.Euler(0, rotationY, 0); // rotar el personaje en y
    }

    void MyInput()
    {
        inputDirection = look.action.ReadValue<Vector2>();

        mouseX = inputDirection.x;
        mouseY = inputDirection.y;

        rotationY += mouseX * sensx *mult; //asignamos que el input en x por la sensibilidad y por el multiplicador sera la rotación que habra en Y
        rotationX -= mouseY * sensy * mult;//lo mismo pero con x

        rotationX = Mathf.Clamp(rotationX, -70f, 70f); //limitamos la rotacion de x para que no puedas dar la vuelta completa de arriba a abajo partiendole el cuello al personaje x-x
    }
}
