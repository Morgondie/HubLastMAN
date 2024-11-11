using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    public float bulletSpeed = 20f;  // Aseg�rate de que la velocidad sea mayor para un movimiento r�pido
    public int damage = 10;          // Da�o del proyectil
    public GameObject hitEffect;     // Efecto que aparece cuando el proyectil impacta

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Aseg�rate de que el proyectil se mueva en la direcci�n correcta
        rb.velocity = transform.forward * bulletSpeed;

        // Destruir el proyectil despu�s de 2 segundos
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si el proyectil golpea un objeto que tiene un collider
        if (collision.gameObject.CompareTag("Player"))
        {
            // Hacer da�o al jugador o a cualquier objeto que desees
            VidaPlayer playerLife = collision.gameObject.GetComponent<VidaPlayer>();
            if (playerLife != null)
            {
                playerLife.vida -= damage;
            }
        }
        else if (collision.gameObject.CompareTag("Enemigo"))
        {
            // Hacer da�o al enemigo
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takedamage(damage);
            }
        }

        // Si se desea un efecto visual en el impacto, puedes instanciarlo aqu�
        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        // Destruir el proyectil despu�s del impacto
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        // Si el proyectil es un trigger, puedes usar esto para detectar colisiones tambi�n
        if (other.CompareTag("Player"))
        {
            // Hacer da�o al jugador
            VidaPlayer playerLife = other.gameObject.GetComponent<VidaPlayer>();
            if (playerLife != null)
            {
                playerLife.vida -= damage;
            }
            Destroy(gameObject);  // Destruir el proyectil al hacer da�o
        }
        else if (other.CompareTag("Enemigo"))
        {
            // Hacer da�o al enemigo
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takedamage(damage);
            }
            Destroy(gameObject);  // Destruir el proyectil al hacer da�o
        }
    }
}
