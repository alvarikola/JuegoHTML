using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        objectPlacement = FindObjectOfType<ObjectPlacement>(); // Encontramos el script ObjectPlacement en la escena

    }

    public Transform holdPosition; // Lugar donde se sostendrá el objeto
    private GameObject heldObject;
    private Rigidbody heldRb;
    private ObjectPlacement objectPlacement; // Referencia al script de ObjectPlacement


    void Update()
    {
        //Vector3 rayOrigin = transform.position + Vector3.up * 0.4f;
        //Debug.DrawRay(rayOrigin, transform.forward * 2f, Color.red);

        if (Input.GetKeyDown(KeyCode.E)) // Presiona "E" para recoger o soltar
        {
            if (heldObject == null)
            {
                TryPickUp();
            }
            else
            {
                DropObject();
            }
        }
    }

    void TryPickUp()
    {
        Debug.Log("Intentando recoger objeto...");

        Vector3 rayOrigin = transform.position + Vector3.up * 0.4f; // Ajuste de altura del Raycast

        Debug.DrawRay(rayOrigin, transform.forward * 2f, Color.green); // Cambié a verde para distinguirlo

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, transform.forward, out hit, 2f))
        {
            Debug.Log("¡Objeto detectado!: " + hit.collider.gameObject.name);

            if (hit.collider.CompareTag("Pickup"))
            {
                heldObject = hit.collider.gameObject;
                heldRb = heldObject.GetComponent<Rigidbody>();

                if (heldRb != null)
                {
                    heldRb.isKinematic = true;
                }

                heldObject.transform.position = holdPosition.position;
                heldObject.transform.rotation = holdPosition.rotation;
                heldObject.transform.parent = holdPosition;
            }
        }
        else
        {
            Debug.Log("⚠️ No se detectó ningún objeto. Ajusta la altura del Raycast.");
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            Debug.Log("Soltando objeto: " + heldObject.name);

            // Desvincular el objeto del personaje
            heldObject.transform.parent = null;

            // Reactivar la física del objeto
            if (heldRb != null)
            {
                heldRb.isKinematic = false; // Para que vuelva a ser afectado por la gravedad
            }

            // Llamamos al script de ObjectPlacement para verificar si el objeto fue colocado correctamente
            objectPlacement.TryPlaceObject(heldObject);

            // Limpiar referencias
            heldObject = null;
            heldRb = null;
        }
    }
}
