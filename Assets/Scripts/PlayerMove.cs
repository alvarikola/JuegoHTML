using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 2F;
    private float horizontalInput;
    private float forwardInput;
    //private GameManager gameManager;
    private Animator animator;
    


    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameManager.isGameActive) { 
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, forwardInput).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

        // Controlar animaciones con el Animator
        // Cambiar el valor de "Speed" en el Animator según la velocidad de movimiento
        animator.SetFloat("Speed_f", movement.magnitude);


        //}
    
    }
}
