using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;
    public GameObject target;
    public bool atacando;

    // Nueva variable para la velocidad
    public float velocidadCaminar = 1f;
    public float velocidadCorrer = 2f;

    void Start()
    {
        ani = GetComponent<Animator>();
        target = GameObject.Find("Link");
    }

    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            cronometro += Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range(0, 2);
                cronometro = 0;
            }
            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);
                    angulo = Quaternion.Euler(0, grado, 0);
                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 100 * Time.deltaTime);
                    transform.Translate(Vector3.forward * velocidadCaminar * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1)
            {
                var looksPos = target.transform.position - transform.position;
                looksPos.y = 0;
                var rotation = Quaternion.LookRotation(looksPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 200 * Time.deltaTime);

                ani.SetBool("walk", false);
                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * velocidadCorrer * Time.deltaTime);

                ani.SetBool("attack", false);
            }
            else
            {
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
                ani.SetBool("attack", true);
                atacando = true;
            }
        }
    }

    public void Final_ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
    }
}
