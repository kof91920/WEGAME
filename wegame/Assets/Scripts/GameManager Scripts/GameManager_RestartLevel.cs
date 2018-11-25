using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace S3
{
    public class GameManager_RestartLevel : MonoBehaviour
    {

        GameManager_Master gameManagerMaster;

        void OnEnable()
        {
            SetInitialReferences();
            gameManagerMaster.RestartLevelEvent += RestartLevel;
        }

        void OnDisable()
        {
            gameManagerMaster.RestartLevelEvent -= RestartLevel;
        }

        void SetInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void RestartLevel()
        {
            SceneManager.LoadScene(1);
        }
    }
}
