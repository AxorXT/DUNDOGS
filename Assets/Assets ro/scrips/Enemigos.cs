using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigos : MonoBehaviour
{
    public int maxHealth = 3; 
    private int currentHealth;
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public GameObject target;
    public bool attack;

    // Velocidades para el Blend Tree
    public float velocidadCaminar = 1f;
    public float velocidadCorrer = 2f;

    // Referencia al agente de NavMesh
    private NavMeshAgent agente;

    void Start()
    {
        ani = GetComponent<Animator>();
        agente = GetComponent<NavMeshAgent>();

        // Configurar velocidades en el NavMeshAgent
        agente.speed = velocidadCaminar;
        agente.stoppingDistance = 1f; // Distancia mínima para detenerse cerca del objetivo
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"{gameObject.name} tiene {currentHealth} puntos de salud restantes.");

        // Verifica si la salud llega a 0
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} ha muerto.");
        Destroy(gameObject); // Destruye al enemigo
    }

    public void Comportamiento_Enemigo()
    {
        float distanciaAlJugador = Vector3.Distance(transform.position, target.transform.position);

        if (distanciaAlJugador > 5) // Estado de patrulla
        {
            cronometro += Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0: // Idle
                    agente.isStopped = true;
                    ani.SetFloat("Speed", 0); // Estado "Idle" en el Blend Tree
                    break;

                case 1: // Elegir dirección aleatoria
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;

                case 2: // Caminar hacia un punto aleatorio
                    Vector3 destinoAleatorio = transform.position + new Vector3(Mathf.Sin(grado), 0, Mathf.Cos(grado)) * 5;
                    NavMeshHit hit;
                    if (NavMesh.SamplePosition(destinoAleatorio, out hit, 5f, NavMesh.AllAreas))
                    {
                        agente.SetDestination(hit.position);
                        agente.isStopped = false;
                        agente.speed = velocidadCaminar;
                        ani.SetFloat("Speed", velocidadCaminar); // Estado "Walk" en el Blend Tree
                    }
                    break;
            }
        }
        else // Estado de persecución
        {
            if (distanciaAlJugador > agente.stoppingDistance) // Perseguir al jugador
            {
                agente.SetDestination(target.transform.position);
                agente.isStopped = false;
                agente.speed = velocidadCorrer;
                ani.SetFloat("Speed", velocidadCorrer); // Estado "Run" en el Blend Tree
            }
            else // Atacar
            {
                agente.isStopped = true;
                ani.SetFloat("Speed", 0); // Estado "Idle" en el Blend Tree
                ani.SetTrigger("attack");
                attack = true;
            }
        }
    }

    public void Final_ani()
    {
        attack = false;
    }

    void Update()
    {
        Comportamiento_Enemigo();
    }
}
