using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HtmlSlot : MonoBehaviour
{
    public int positionNumber; // Posición en la estructura (1, 2, 3)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        HtmlElement htmlElement = other.GetComponent<HtmlElement>();
        if (htmlElement != null)
        {
            if (htmlElement.correctPosition == positionNumber)
            {
                Debug.Log("✅ " + htmlElement.htmlTag + " colocado correctamente en la posición " + positionNumber);
                GameManager.instance.AddScore();
            }
            else
            {
                Debug.Log("❌ " + htmlElement.htmlTag + " está en la posición incorrecta.");
            }
        }
    }
}
