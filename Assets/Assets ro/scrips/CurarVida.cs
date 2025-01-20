using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurarVida : MonoBehaviour
{
    public VidaJugador vidaJugador;
    public bool PuedeCurar = true; // Se añadió esta variable para controlar si se puede curar

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PuedeCurar)
        {
            vidaJugador.ObtenerVida(1);
            PuedeCurar = false; // Desactiva la curación después de usarla
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PuedeCurar = true; // Reactiva la curación cuando el jugador sale del trigger
        }
    }
}
