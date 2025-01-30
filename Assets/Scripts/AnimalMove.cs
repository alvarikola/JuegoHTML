using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMove : MonoBehaviour
{
    private float speed = 1f; // Velocidad de movimiento del animal
    private float roamRadius = 9f; // Radio del área en la que puede moverse el animal
    private float changeDirectionTime = 2f; // Tiempo para cambiar de dirección

    private Vector3 targetPosition;
    private float timeToChangeDirection;

    void Start()
    {
        timeToChangeDirection = changeDirectionTime;
        SetRandomTargetPosition();
    }

    void Update()
    {
        timeToChangeDirection -= Time.deltaTime;

        // Si el tiempo para cambiar dirección ha pasado, asignamos una nueva dirección
        if (timeToChangeDirection <= 0f)
        {
            SetRandomTargetPosition();
            timeToChangeDirection = changeDirectionTime;
        }

        // Mover el animal hacia la posición objetivo
        MoveToTarget();
    }

    // Establece una nueva posición aleatoria dentro del radio permitido
    void SetRandomTargetPosition()
    {
        float randomX = Random.Range(-roamRadius, roamRadius);
        float randomZ = Random.Range(-roamRadius, roamRadius);

        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }

    // Mueve el animal hacia la posición objetivo
    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (transform.position != targetPosition)
        {
            // Calculamos la dirección hacia la que el animal debe mirar
            Vector3 direction = targetPosition - transform.position;
            direction.y = 0; // Aseguramos que la rotación no afecte el eje Y (rotación en el plano XZ)

            // Rotamos el animal para que mire en la dirección correcta
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        }
    }
}
