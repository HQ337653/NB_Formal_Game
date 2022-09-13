using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//switch character between 3d and 2d
//set Ui when the character is enabled 
namespace NBGame.Player
{
    public class CharaModeSwitcher : MonoBehaviour
    {
        public charaControllerThreeD ThreeDdScript;
        public charaControllerTwoD TwoDdScript;
        [SerializeField]
        CharaChangeUiEvents charaChangeUiEvents;
        [SerializeField]
        Sprite EImage;
        [SerializeField]
        Sprite QImage;
        [SerializeField]
        Sprite normalImage;
        [SerializeField]
        Sprite dashImage;

        public Sprite charaIcon;


        [SerializeField]
         GameObject specialBarPrefeb;
        [SerializeField]
       public GameObject specialBar;

        public bool TwoD;
        //protected characterHealthObj Hp;

        private void OnEnable()
        {
            setUi();
        }

        void setUi()
        {
            charaChangeUiEvents.AllCharaRelatedUiChanged(EImage, QImage, normalImage, dashImage);

        }
        private void Awake()
        {
            GameModeController.ModeChangediFTo2D += change;
            TwoDdScript.enabled = true;
            TwoDdScript.enabled = false;
            ThreeDdScript.enabled = true;
            specialBar = Instantiate(specialBarPrefeb);

            GameModeController.PauseGame += pause;
        }

        private void pause(bool i)
        {
            if (i)
            {
                TwoDdScript.enabled = false;
                ThreeDdScript.enabled = false;
            }
            else
            {
                TwoDdScript.enabled = TwoD;
                ThreeDdScript.enabled = !TwoD;
            }
        }

        private void change(bool IsTwoD)
        {
            TwoD = IsTwoD;
            TwoDdScript.enabled = TwoD;
            ThreeDdScript.enabled = !TwoD;
        }

        private void OnDestroy()
        {
            GameModeController.ModeChangediFTo2D -= change;
        }

        public void charaEnterScene()
        {
            if (TwoDdScript.enabled)
            {
                TwoDdScript.SwitchToScene();
            }
            if (ThreeDdScript.enabled)
            {
                ThreeDdScript.SwitchToScene();
            }
        }

        internal void characterLeaveScene()
        {
            if (TwoDdScript.enabled)
            {
                TwoDdScript.LeaveScene();
            }
            if (ThreeDdScript.enabled)
            {
                ThreeDdScript.LeaveScene();
            }
        }
    }
}
