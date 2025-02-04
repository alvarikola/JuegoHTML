using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HtmlElement : MonoBehaviour
{
    public string htmlTag; // Puede ser "<div>", "text", "</div>"
    public int correctPosition; // Posición correcta (1 = apertura, 2 = contenido, 3 = cierre)
    private TextMeshPro textUI; // Referencia al texto en el objeto

    // Start is called before the first frame update
    void Start()
    {
        // Buscar el objeto hijo "TextUI" y asignarlo
        textUI = GetComponentInChildren<TextMeshPro>();
        if (textUI != null)
        {
            textUI.text = htmlTag; // Mostrar el contenido del objeto en el texto
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetElement(string tag, int position)
    {
        htmlTag = tag;
        correctPosition = position;

        // Actualizar el texto cuando se cambie el contenido
        if (textUI != null)
        {
            textUI.text = htmlTag;
        }
    }
}
