using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyC : MonoBehaviour
{
    public float visionRange = 10f; // Alcance de visi�n del enemigo
    public float attackRange = 2f; // Distancia a la que el enemigo atacar� al jugador
    public float moveSpeed = 3f; // Velocidad de movimiento del enemigo
    public LayerMask playerLayer; // Capa que contiene al jugador

    [SerializeField] Transform player; // Referencia al jugador
    private bool isPlayerInRange = false; // Estado de detecci�n del jugador
    public Color rayColor = Color.red; // Color del Raycast

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Busca al jugador por la etiqueta "Player"
    }

    void Update()
    {
        // Si el jugador est� en rango de visi�n
        if (Physics2D.Raycast(transform.position, player.position - transform.position, visionRange, playerLayer))
        {
            // El Raycast detecta al jugador, realiza las acciones correspondientes
            isPlayerInRange = true;

            // Si el jugador est� dentro del rango de ataque, ataca
            if (Vector2.Distance(transform.position, player.position) <= attackRange)
            {
                AttackPlayer();
            }
            else
            {
                // Si el jugador est� fuera del rango de ataque, persigue al jugador
                ChasePlayer();
            }
        }
        else
        {
            isPlayerInRange = false;
        }

        // Dibujar el rango de visi�n con un Raycast y un color espec�fico
        Debug.DrawRay(transform.position, (player.position - transform.position).normalized * visionRange, rayColor);
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    void AttackPlayer()
    {
        
        Debug.Log("�Atacando al jugador!");
    }
}

