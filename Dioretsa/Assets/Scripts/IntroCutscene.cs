using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroCutscene : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    private string[] introTexts = new string[4] {
        "\"Captain, someone arranged the asteroids in a strange pattern...\"",
        "\"Do you think it could be aliens?\"",
        "\"No. It's something far, far worse...\"",
        "\"Math nerds.\"",
    
    };

    private float[] textTimes = new float[4] {5, 4, 6, 3};

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
            textMesh.text = "";
            yield return new WaitForSeconds(0.5f);
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");
        while (!asyncLoad.isDone)
        { 
            yield return null;
        }
    }

}
