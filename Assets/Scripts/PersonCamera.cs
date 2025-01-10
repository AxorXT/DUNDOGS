using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCamera : MonoBehaviour
{
    public Transform target; // Personaje que sigue la c�mara
    public Vector3 offset = new Vector3(0, 5, -1); // Offset inicial
    public float smoothSpeed = 0.125f; // Velocidad de suavizado
    public float rotationSpeed = 100f; // Velocidad de rotaci�n
    public float zoomSpeed = 2f; // Velocidad de zoom
    public float minZoom = -5f; // Distancia m�nima
    public float maxZoom = -20f; // Distancia m�xima

    private float currentRotationAngle = 0f;

    void LateUpdate()
    {
        // Control de rotaci�n de la c�mara
        float horizontalInput = Input.GetAxis("Mouse X");
        currentRotationAngle += horizontalInput * rotationSpeed * Time.deltaTime;

        Quaternion rotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // Ajuste din�mico de la distancia con la rueda del rat�n
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        offset.z = Mathf.Clamp(offset.z + scrollInput * zoomSpeed, maxZoom, minZoom);

        // Calcular la posici�n deseada
        Vector3 desiredPosition = target.position + rotation * offset;

        // Suavizar el movimiento
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Asegurar que la c�mara apunte al personaje
        transform.LookAt(target);
    }
}