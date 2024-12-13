using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCamera : MonoBehaviour
{
    public Transform target; // Personaje que sigue la c�mara
    public Vector3 offset = new Vector3(0, 5, -10); // Offset inicial
    public float smoothSpeed = 0.125f; // Velocidad de suavizado
    public float rotationSpeed = 100f; // Velocidad de rotaci�n

    private float currentRotationAngle = 0f;

    private void Start()
    {
        // Inicializa la posici�n correcta de la c�mara al inicio
        transform.position = target.position + offset;
    }

    void LateUpdate()
    {
        // Control de rotaci�n de la c�mara
        float horizontalInput = Input.GetAxis("Mouse X");
        currentRotationAngle += horizontalInput * rotationSpeed * Time.deltaTime;

        Quaternion rotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Calcular la posici�n deseada
        Vector3 desiredPosition = target.position + rotation * offset;

        // Suavizar el movimiento
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Asegurar que la c�mara apunte al personaje
        transform.LookAt(target);
    }
}