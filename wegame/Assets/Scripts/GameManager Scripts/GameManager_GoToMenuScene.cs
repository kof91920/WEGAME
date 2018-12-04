using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace S3
{
    public class GameManager_GoToMenuScene : MonoBehaviour
    {
        GameManager_Master gameManagerMaster;

        void OnEnable()
        {
            SetInitialReferences();
            gameManagerMaster.GoToMenuSceneEvent += GoToMenuScene;
        }

        void OnDisable()
        {
            gameManagerMaster.GoToMenuSceneEvent -= GoToMenuScene;
        }

        void SetInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void GoToMenuScene()
        {
            SceneManager.LoadScene(0);
        }
    }
}
