using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene("pete-the-penguin 6");
       
    }
    public void ExitGame()
    {
        Application.Quit();
    }


}
