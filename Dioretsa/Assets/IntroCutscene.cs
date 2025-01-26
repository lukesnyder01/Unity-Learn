using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCutscene : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    private string[] introTexts = new string[4] {
        "Captain, someone arranged the asteroids in strange pattern...",
        "Sir, do you think it could be aliens?",
        "No, much worse. It's...",
        "Nerds",
    
    };

    private float[] textTimes = new float[4] {4, 3, 3, 5};

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        StartCoroutine(PlayIntroCutscene());

    }

    private IEnumerator PlayIntroCutscene()
    {
        for (int i = 0; i < introTexts.Length; i++)
        {
            textMesh.text = introTexts[i];
            yield return new WaitForSeconds(textTimes[i]);
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");
        while (!asyncLoad.isDone)
        { 
            yield return null;
        }
    }

}
