using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionPersonaje : MonoBehaviour
{
    // Referencia al Animator del prefab
    private Animator animator;

    // Variables para controlar el movimiento
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        // Obtener el componente Animator del prefab
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Leer el movimiento del jugador (teclas WASD o flechas)
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Determinar si el personaje está en movimiento
        bool isMoving = Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f;

        // Activar la animación de caminar/moverse
        animator.SetBool("isMoving", isMoving);

        // Activar animación especial ATACAR 
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Ataque");
        }

        // Animacion DEFENDER
        if (Input.GetMouseButton(1))
        {
            animator.SetTrigger("Ataque2");
        }

        // Animacion DEFENDER
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Defensa");
        }
    }
}
