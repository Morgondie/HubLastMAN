using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyType { Melee, Ranged }

public class Enemy : MonoBehaviour
{
    public Transform Objetivo;
    public float velocidad;
    public NavMeshAgent AI;

    public float _vidaenemigo = 50;
    public int damage;
    public GameObject Player;

    public EnemyType enemyType = EnemyType.Melee;  // Tipo de enemigo (cuerpo a cuerpo o a distancia)
    public float attackRange = 10f;  // Rango para atacar (solo para enemigos a distancia)
    public float attackCooldown = 2f;  // Tiempo entre ataques a distancia
    private float lastAttackTime = 0f;

    // Para el ataque a distancia
    public GameObject projectilePrefab;
    public Transform shootPoint;

    void Update()
    {
        AI.speed = velocidad;

        if (enemyType == EnemyType.Melee)
        {
            // Enemigos cuerpo a cuerpo
            AI.SetDestination(Objetivo.position);
        }
        else if (enemyType == EnemyType.Ranged)
        {
            // Enemigos a distancia
            AttackAtRange();
        }
    }

    public void takedamage(float _damage)
    {
        _vidaenemigo -= _damage;

        if (_vidaenemigo <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void AttackAtRange()
    {
        // Verifica la distancia con el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, Player.transform.position);

        if (distanceToPlayer <= attackRange && Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        // Dispara un proyectil en dirección al jugador
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.LookRotation((Player.transform.position - shootPoint.position).normalized));
        Vector3 direction = (Player.transform.position - shootPoint.position).normalized;
        projectile.GetComponent<Rigidbody>().velocity = direction * 10f;  // Ajusta la velocidad del proyectil
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && enemyType == EnemyType.Melee)
        {
            // Si es un enemigo cuerpo a cuerpo, hace daño directamente al jugador
            Player.GetComponent<VidaPlayer>().vida -= damage;
        }

        if (other.tag == "Enemigo")
        {
            Debug.Log("Enemigo");
        }
    }
}
