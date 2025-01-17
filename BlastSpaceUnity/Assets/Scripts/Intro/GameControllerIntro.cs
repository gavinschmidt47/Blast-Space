using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControllerIntro : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {   
        StartCoroutine(FadeOutText());
        StartCoroutine(LoadGameScene());
    }

    IEnumerator LoadGameScene()
    {
        yield return new WaitForSeconds(4);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    IEnumerator FadeOutText()
    {
        yield return new WaitForSeconds(2);
        Color originalColor = text.color;
        for (float t = 0.01f; t < 2f; t += Time.deltaTime)
        {
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(1, 0, Mathf.Min(1, t / 2f)));
            yield return null;
        }
        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);
    }
}
