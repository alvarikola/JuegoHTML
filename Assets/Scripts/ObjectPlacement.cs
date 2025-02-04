using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform[] placementPoints; // Puntos donde los objetos deben ser colocados
    public float placementRange = 1.5f; // Radio de aceptación para colocar el objeto
    public int score = 0; // Puntos por colocar objetos correctamente

    // Este método se llamará cuando el objeto sea soltado
    public void TryPlaceObject(GameObject objectToPlace)
    {
        foreach (Transform point in placementPoints)
        {
            // Verificamos si el objeto está dentro del rango de la posición
            if (Vector3.Distance(objectToPlace.transform.position, point.position) <= placementRange)
            {
                // Si el objeto está dentro del rango, asignamos puntos y lo dejamos en la posición correcta
                objectToPlace.transform.position = point.position;
                objectToPlace.transform.rotation = point.rotation; // Alineamos la rotación también si es necesario
                objectToPlace.transform.parent = point; // Asignamos el objeto al punto

                // Aumentamos el puntaje
                score++;
                Debug.Log("¡Objeto colocado correctamente! Puntos: " + score);

                return; // Salimos del ciclo cuando encontramos el primer punto
            }
        }

        Debug.Log("El objeto no está en un punto de colocación válido.");
    }
}
