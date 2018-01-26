using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    public Text score;
    public Text highScore;

    private void Start()
    {
        //also important for future projects
        highScore.text = PlayerPrefs.GetInt("High Score", 0).ToString();
    }

    public void RollDice()
    {
        int result = Random.Range(1, 7);
        score.text = result.ToString();
        if (result > PlayerPrefs.GetInt("High Score", 0))
        //The following is the code that's important to take for future projects - playerPrefs 
        {
            PlayerPrefs.SetInt("High Score", result);
            highScore.text = result.ToString();
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("High Score");
        highScore.text = "0";
    }
}
