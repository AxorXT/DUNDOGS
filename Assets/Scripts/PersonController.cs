using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 720f;
    public Transform cameraTransform;

    private CharacterController characterController;
    private Vector3 moveDirection;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("No se encontr� un CharacterController en " + gameObject.name);
        }
    }

    void Update()
    {
        // Leer entrada del usuario
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcular direcci�n del movimiento
        Vector3 inputDirection = new Vector3(horizontal, 0f, vertical).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            // Calcular el �ngulo de rotaci�n relativo a la c�mara
            float targetAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);

            // Rotar el personaje hacia la direcci�n deseada
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Mover en la direcci�n orientada por la c�mara
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        // Aplicar gravedad
        moveDirection.y += Physics.gravity.y * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
