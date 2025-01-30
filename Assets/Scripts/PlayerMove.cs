using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 2F;
    private float horizontalInput;
    private float forwardInput;
    //private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameManager.isGameActive) { 
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            // Moves the car forward based on vertical input
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            // Rotates the car based on horizontal input
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        //}
    
    }
}
