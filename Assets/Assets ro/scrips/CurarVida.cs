using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurarVida : MonoBehaviour
{

    public VidaJugador vidaJugador;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PuedeDa�ar)
        {
            vidaJugador.ObtenerVida(1);

        }
    }
}