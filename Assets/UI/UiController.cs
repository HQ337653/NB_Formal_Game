using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//collect all the Uis function into one script 
namespace NBGame.UI
{
    public class UiController : MonoBehaviour
    {
        [SerializeField]
        public ButtonSetter E;
        [SerializeField]
        public ButtonSetter Q;
        [SerializeField]
        public ButtonSetter Normal;
        [SerializeField]
        public ButtonSetter Dash;
        [SerializeField]
        private GameObject Atk;
        [SerializeField]
        private GameObject NotAtk;
        [SerializeField]
        public GameObject Health;
        [SerializeField]
        public GameObject Movement;
        [SerializeField]
        public GameObject Characters;

        public BarSetter SpecialBar;
        public SimpleBarSetter HealthBar;
        public SimpleBarSetter EnergyBar;

        private void Awake()
        {
            GameModeController.CharacterChangedIfToActive += switchMode;
            GameModeController.ModeChangediFTo2D += switchAtkUi;
        }
        #region changeUiPicture

        public void setAllUi(Sprite E, Sprite Q, Sprite normal, Sprite Dash)
        {
            changeE(E);
            changeQ(Q);
            changeNormal(normal);
            changeDash(Dash);
        }

        public void changeE(Sprite texture)
        {
            E.setTexture(texture);
        }
        public void changeQ(Sprite texture)
        {
            Q.setTexture(texture);
        }
        public void changeNormal(Sprite texture)
        {
            Normal?.setTexture(texture);
        }
        public void changeDash(Sprite texture)
        {
            Dash?.setTexture(texture);
        }

        public void changeSpecialBar(Vector2 size, Sprite texture)
        {
            Debug.Log("change SpecialBar ");
        }
        #endregion

        #region highlight button
        public void HighLightQ(bool highLight)
        {
            Debug.Log("HighLightQ");
        }
        public void HighLightE(bool highLight)
        {
            Debug.Log("set E coolDown");
        }

        #endregion

        #region setCoolDown
        public void setEcooldown(float time)
        {

        }
        public void setQcooldown(float time)
        {

        }
        #endregion

        #region changeBar
        public void changeHp(float percent)
        {
            HealthBar.setValue(percent);
        }

        public void changeEnergy(float percent)
        {
            EnergyBar.setValue(percent);
        }

        public void changeSpecialBarVal(float percent)
        {
            SpecialBar.setValue(percent);
        }

        #endregion

        #region set part active
        public void switchMode(bool i)
        {
            gameObject.SetActive(i);
        }

        public void switchAtkUi(bool Notatk)
        {
            Debug.Log("calleds");
            Atk.SetActive(!Notatk);
            NotAtk?.SetActive(Notatk);
        }

        public void disActiveAtkPart()
        {
            Atk.SetActive(false);
            NotAtk?.SetActive(false);
        }

        public void switchHealthUi(bool show)
        {
            Health.SetActive(show);
        }

        public void switchMovementUi(bool show)
        {
            Movement?.SetActive(show);
        }

        public void switchChareUi(bool show)
        {
            Characters.SetActive(show);
        }
        #endregion

    }
}
