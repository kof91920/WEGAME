using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

namespace S3
{
    public class GameManager_RestartLevel : MonoBehaviour
    {

        GameManager_Master gameManagerMaster;
        //private Text timer;
        //private float seconds, minutes;
        public GameObject timer;
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
            print("hahahahahaw");
            
            SceneManager.LoadScene("pete-the-penguin 6");
        }
    }
}
