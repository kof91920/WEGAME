using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    // score of the player
    public int score = 0;

    // high score of the game
    public int highScore = 0;

    // current level
    public int currentLevel = 1;

    // how levels there are
    public int highestLevel = 2;

    // HUD manager
    HudManager hudManager;

    // static instance of the GM can be accessed from anywhere
    public static GameManager instance;

    void Awake()
    {
        // check that it exists
        if(instance == null)
        {
            //assign it to the current object
            instance = this;
        }

        // make sure that it is equal to the current object
        else if(instance != this)
        {
            // find an object of type HudManager
            instance.hudManager = FindObjectOfType<HudManager>();

            // destroy the current game object - we only need 1 and we already have it!
            Destroy(gameObject);
        }

        // don't destroy this object when changing scenes!
        DontDestroyOnLoad(gameObject);

        // find an object of type HudManager
        hudManager = FindObjectOfType<HudManager>();
    }

    // increase the player score
    public void IncreaseScore(int amount)
    {
        // increase score by the amount
        score += amount;

        // update the HUD
        if(hudManager != null)
            hudManager.ResetHud();

        // show the new score
        print("new score: " + score);

        // have we surpassed our high score?
        if(score > highScore)
        {
            // save a new high score
            highScore = score;

            print("new record! " + highScore);
        }
    }

    // reset the game
    public void ResetGame()
    {
        // reset our score
        score = 0;

        // update the HUD
        if (hudManager != null)
            hudManager.ResetHud();

        // set the current level to 1
        currentLevel = 1;

        // load the level 1 
        SceneManager.LoadScene("Level1");
    }

    // send the player to the next level
    public void IncreaseLevel()
    {
        // check if there are more levels
        if(currentLevel < highestLevel)
        {
            // increase currentLevel by 1
            currentLevel++;
        }
        else
        {
            // we are gonna go back to level 1
            currentLevel = 1;
        }

        SceneManager.LoadScene("Level" + currentLevel);
    }  

    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    
}
