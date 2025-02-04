using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(1, 2, 3);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() {
        // Ajustar la posición de la cámara
        transform.position = player.transform.position + offset;

        // Hacer que la cámara siempre mire al jugador
        transform.LookAt(player.transform);
    }
}
