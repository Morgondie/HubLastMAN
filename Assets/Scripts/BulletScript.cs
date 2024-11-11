using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletScript : MonoBehaviour
{
    private Rigidbody rb;
    public float bulletSpeed = 20f;  // Asegúrate de que la velocidad sea mayor para un movimiento rápido
    public int damage = 10;          // Daño del proyectil
    public GameObject hitEffect;     // Efecto que aparece cuando el proyectil impacta

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Asegúrate de que el proyectil se mueva en la dirección correcta
        rb.velocity = transform.forward * bulletSpeed;

        // Destruir el proyectil después de 2 segundos
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Si el proyectil golpea un objeto que tiene un collider
        if (collision.gameObject.CompareTag("Player"))
        {
            // Hacer daño al jugador o a cualquier objeto que desees
            VidaPlayer playerLife = collision.gameObject.GetComponent<VidaPlayer>();
            if (playerLife != null)
            {
                playerLife.vida -= damage;
            }
        }
        else if (collision.gameObject.CompareTag("Enemigo"))
        {
            // Hacer daño al enemigo
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takedamage(damage);
            }
        }

        // Si se desea un efecto visual en el impacto, puedes instanciarlo aquí
        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        // Destruir el proyectil después del impacto
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        // Si el proyectil es un trigger, puedes usar esto para detectar colisiones también
        if (other.CompareTag("Player"))
        {
            // Hacer daño al jugador
            VidaPlayer playerLife = other.gameObject.GetComponent<VidaPlayer>();
            if (playerLife != null)
            {
                playerLife.vida -= damage;
            }
            Destroy(gameObject);  // Destruir el proyectil al hacer daño
        }
        else if (other.CompareTag("Enemigo"))
        {
            // Hacer daño al enemigo
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.takedamage(damage);
            }
            Destroy(gameObject);  // Destruir el proyectil al hacer daño
        }
    }
}
