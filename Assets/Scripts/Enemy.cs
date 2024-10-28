using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform Objetivo;
    public float velocidad;
    public NavMeshAgent AI;

    public float _vidaenemigo = 50;
    public int damage;
    public GameObject Player;

    void Update()
    {
        AI.speed = velocidad;
        AI.SetDestination(Objetivo.position);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.GetComponent<VidaPlayer>().vida -= damage;
        }

        if (other.tag == "Enemigo")
        {
            Debug.Log("Enemigo");
        }
    }
}
