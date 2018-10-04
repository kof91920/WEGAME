using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

    // access to the text element that shows the score value
    public Text scoreValue;

    // access to high score value
    public Text highScoreValue;

	// Use this for initialization
	void Start () {
        // set the "text" of our Score Value
        scoreValue.text = GameManager.instance.score.ToString();

        // set the "text" of our High Score Value
        highScoreValue.text = GameManager.instance.highScore.ToString();
    }
	
    // it will send the player to level 1
	public void RestartGame()
    {
        GameManager.instance.ResetGame();
        SceneManager.LoadScene("Level 1");
    }
}
