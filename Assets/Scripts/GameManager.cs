using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;
    public int currentLevel = 1;
    private int correctPlacements = 0;
    private HashSet<GameObject> placedObjects = new HashSet<GameObject>();
    public GameObject panel;

    [Header("Configuración de Nivel")]
    public List<string> htmlTags; // Lista de etiquetas que puedes modificar en Unity

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        LoadLevel(currentLevel);
        panel = GameObject.Find("Panel");
        panel.SetActive(false);

    }

    public void LoadLevel(int level)
    {
        correctPlacements = 0;
        placedObjects.Clear();

        if (htmlTags.Count == 0)
        {
            Debug.LogError($"⚠ No hay etiquetas HTML asignadas para el nivel {level}. Agrégalas en el Inspector.");
            return;
        }

        Debug.Log($"📢 Cargando nivel {level} con etiquetas: {string.Join(", ", htmlTags)}");

        // Buscar TODOS los HtmlElement en la escena
        HtmlElement[] elements = FindObjectsOfType<HtmlElement>();

        for (int i = 0; i < elements.Length; i++)
        {
            if (i < htmlTags.Count)
            {
                elements[i].SetElement(htmlTags[i], i + 1);
                elements[i].gameObject.SetActive(true);
                elements[i].transform.position = new Vector3(Random.Range(-2f, 2f), 1, Random.Range(-2f, 2f));
            }
            else
            {
                elements[i].gameObject.SetActive(false);
            }
        }
    }

    public void ObjectPlacedCorrectly(GameObject obj)
    {
        if (!placedObjects.Contains(obj))
        {
            placedObjects.Add(obj);
            correctPlacements++;

            Debug.Log($"✅ Objeto colocado correctamente. Total: {correctPlacements}/{htmlTags.Count}");

            if (correctPlacements == htmlTags.Count)
            {
                Debug.Log("✅ Nivel Completado. Cargando siguiente...");
                StartCoroutine(LoadNextScene());
            }
        }
        else
        {
            Debug.Log("⚠ Este objeto ya fue colocado.");
        }
    }

    private IEnumerator LoadNextScene()
    {
        currentLevel++;
        string nextSceneName = "Nivel" + currentLevel;

        yield return new WaitForSeconds(1f); // Pequeño delay para evitar problemas

        if (SceneExists(nextSceneName))
        {
            Debug.Log($"🔄 Cargando {nextSceneName}...");
            SceneManager.LoadScene(nextSceneName);
            yield return new WaitForSeconds(0.5f);
            LoadLevel(currentLevel); // Asegura que los objetos se actualicen después del cambio de escena
        }
        else
        {
            Debug.Log("🏆 ¡Todos los niveles completados! No hay más escenas.");
            panel.SetActive(true);
        }
    }

    private bool SceneExists(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneFileName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            if (sceneFileName == sceneName)
                return true;
        }
        return false;
    }
}
