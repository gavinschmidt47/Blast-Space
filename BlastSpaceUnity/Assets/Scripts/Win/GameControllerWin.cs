using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControllerWin : MonoBehaviour
{
    public TMP_Text scoreDisplay;

    public TMP_Text highScoreDisplay;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainScene");
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score");
        scoreDisplay.text = score.ToString();

        if (PlayerPrefs.GetInt("Score", 0) > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        highScoreDisplay.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
