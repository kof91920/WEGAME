using UnityEngine;
using System.Collections;

    public class GameManager_TogglePlayer : MonoBehaviour
    {
        //public FirstPersonController playerController;
        GameManager_Master gameManagerMaster;
        private playerLook cam;
        private playerMove playerMove;
        void OnEnable()
        {
            SetInitialReferences();
            gameManagerMaster.MenuToggleEvent += TogglePlayerController;
            gameManagerMaster.InventoryUIToggleEvent += TogglePlayerController;
        }

        void OnDisable()
        {
            gameManagerMaster.MenuToggleEvent -= TogglePlayerController;
            gameManagerMaster.InventoryUIToggleEvent -= TogglePlayerController;

        }

        void SetInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
            playerMove = GameObject.Find("Player").GetComponent<playerMove>();
            cam = GameObject.FindWithTag("MainCamera").GetComponent<playerLook>();
        }

        void TogglePlayerController()
        {
            if (cam != null && playerMove != null)
            {
                cam.enabled = !cam.enabled;
                playerMove.enabled = !playerMove.enabled;
            }
        }
    }

