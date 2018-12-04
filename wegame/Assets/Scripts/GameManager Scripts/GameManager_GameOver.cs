using UnityEngine;
using System.Collections;

namespace S3
{
    public class GameManager_GameOver : MonoBehaviour
    {

        GameManager_Master gameManagerMaster;
        public GameObject panelGameOver;

        void OnEnable()
        {
            SetInitialReferences();
            gameManagerMaster.GameOverEvent += TurnOnGameOverPanel;
        }

        void OnDisable()
        {
            gameManagerMaster.GameOverEvent -= TurnOnGameOverPanel;
        }

        void SetInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void TurnOnGameOverPanel()
        {
            if(panelGameOver != null)
            {
                panelGameOver.SetActive(true);
            }
        }
    }
}
