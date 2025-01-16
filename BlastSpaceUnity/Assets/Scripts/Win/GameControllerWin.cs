using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControllerWin : MonoBehaviour
{
    public TMP_Text scoreDisplay;

    public TMP_Text highScoreDisplay;

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
