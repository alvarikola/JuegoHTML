using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetHtmlElements();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore()
    {
        score ++;
        Debug.Log("🎉 Puntos: " + score);
    }

    public void SetHtmlElements()
    {
        HtmlElement[] elements = FindObjectsOfType<HtmlElement>();

        string[] tags = { "<div>", "text", "</div>" };
        int[] positions = { 1, 2, 3 };

        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].SetElement(tags[i], positions[i]);
        }
    }
}
