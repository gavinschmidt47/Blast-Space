using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControllerWin : MonoBehaviour
{
    public TMP_Text scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score");
        scoreDisplay.text = score.ToString();
    }
}
