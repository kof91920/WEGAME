using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    private KeyCode keybind = KeyCode.Escape;
    private bool paused = false;
    public GameObject PauseMenu;
    public GameObject DisablePlayer;
    public void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "pete-the-penguin")
        {
            callPauseMenu(keybind);
        }
    }

    public void ChangeScript(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void callPauseMenu(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            if (paused)
            {
                PauseMenu.SetActive(false);
                Time.timeScale = 1f;
                paused = false;
                DisablePlayer.SetActive(true);
            }
            else
            {
                PauseMenu.SetActive(true);
                Time.timeScale = 0f;
                paused = true;
                DisablePlayer.SetActive(false);
            }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        DisablePlayer.SetActive(false);
    }
}
