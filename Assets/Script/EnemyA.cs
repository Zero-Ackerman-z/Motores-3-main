using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 2f;

    private Transform targetPoint;

    private void Start()
    {
        // Inicialmente, el objetivo es el punto A.
        targetPoint = pointA;
    }

    private void Update()
    {
        // Calcula la dirección hacia el punto objetivo.
        Vector2 direction = (targetPoint.position - transform.position).normalized;

        // Calcula la nueva posición.
        Vector2 newPosition = (Vector2)transform.position + (direction * moveSpeed * Time.deltaTime);

        // Crea un nuevo vector para la posición.
        Vector3 newPositionVector3 = new Vector3(newPosition.x, newPosition.y, transform.position.z);

        // Asigna la nueva posición al transform.
        transform.position = newPositionVector3;

        // Si el enemigo llega al punto objetivo, cambia el objetivo.
        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            if (targetPoint == pointA)
            {
                targetPoint = pointB;
            }
            else
            {
                targetPoint = pointA;
            }
        }

    }
}
