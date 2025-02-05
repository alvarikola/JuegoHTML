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
                htmlElement.SetPlacedCorrectly(true);
                GameManager.instance.ObjectPlacedCorrectly(other.gameObject);
                // GameManager.instance.AddScore();
                Debug.Log("✅ " + htmlElement.htmlTag + " colocado correctamente en la posición " + positionNumber);
            }
            else
            {
                htmlElement.SetPlacedCorrectly(false);
                Debug.Log("❌ " + htmlElement.htmlTag + " está en la posición incorrecta.");
            }
        }
    }
}
