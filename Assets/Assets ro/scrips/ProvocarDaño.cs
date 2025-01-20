using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvocarDaño : MonoBehaviour
{
    public VidaJugador vidaJugador;
    public bool PuedeDañar = true;
    public float Cooldown = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && PuedeDañar)
        {
            vidaJugador.RecibirDaño(1);
            PuedeDañar = false; // Desactiva el daño temporalmente
            StartCoroutine(CooldownDaño());
        }
    }

    IEnumerator CooldownDaño()
    {
        yield return new WaitForSeconds(Cooldown);
        PuedeDañar = true; // Reactiva el daño después del cooldown
    }
}
