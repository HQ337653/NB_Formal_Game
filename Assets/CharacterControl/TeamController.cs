using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NBGame.CameraMovement;
using NBGame.UI;
//load character based on the given prefeb
//
namespace NBGame.Player
{
    public class TeamController : MonoBehaviour
    {
        //Prefeb
        private GameObject CharaOne;
        private GameObject CharaTwo;
        private GameObject CharaThree;
        private GameObject CharaFour;
        //ObjInScene
        public GameObject CharaOnePre;
        public GameObject CharaTwoPre;
        public GameObject CharaThreePre;
        public GameObject CharaFourPre;

        private Dictionary<int, GameObject> characters;

        public int currentCharacter;
        Transform lastTrans;

        public bool ableToChange = true;
        [SerializeField]
        private CameraAnchor cam;
        [SerializeField]
        private UiController UiController;
        private void Awake()
        {
            currentCharacter = 1;
            GameModeController.CharacterChangedIfToActive += setActivation;
            characters = new Dictionary<int, GameObject>();
            Load();
            lastTrans = this.transform;
        }
        void subScribe(CharaChangeUiEvents e)
        {
            e.HpChanged += UiController.changeHp;
            e.EnegryChanged += UiController.changeEnergy;
            e.SpecialBarChanged += UiController.changeSpecialBarVal;
            //time
            e.ETimeChanged += UiController.setEcooldown;
            e.QTimeChanged += UiController.setQcooldown;
            //highLight
            e.highLightE += UiController.HighLightE;
            e.highLightQ += UiController.HighLightQ;
            //changeShape
            e.setBar += UiController.changeSpecialBar;
            e.changeEButton += UiController.changeE;
            e.changeQButton += UiController.changeQ;
            e.changeNormalButton += UiController.changeNormal;
            e.changeDashButton += UiController.changeDash;
        }
        void UnsubScribe(CharaChangeUiEvents e)
        {
            e.HpChanged -= UiController.changeHp;
            e.EnegryChanged -= UiController.changeEnergy;
            e.SpecialBarChanged -= UiController.changeSpecialBarVal;
            //time
            e.ETimeChanged -= UiController.setEcooldown;
            e.QTimeChanged -= UiController.setQcooldown;
            //highLight
            e.highLightE -= UiController.HighLightE;
            e.highLightQ -= UiController.HighLightQ;
            //changeShape
            e.setBar -= UiController.changeSpecialBar;
            e.changeEButton -= UiController.changeE;
            e.changeQButton -= UiController.changeQ;
            e.changeNormalButton -= UiController.changeNormal;
            e.changeDashButton -= UiController.changeDash;
        }

        #region x
        void changeE(Sprite s)
        {
            Debug.Log("changeE called");
            UiController.changeE(s);
        }
        void changeQ(Sprite s)
        {
            Debug.Log("changeQ called");
            UiController.changeQ(s);
        }
        void changeNormal(Sprite s)
        {
            Debug.Log("changeNormal called");
            UiController.changeNormal(s);
        }
        void changeDash(Sprite s)
        {
            Debug.Log("changeDash called");
            UiController.changeDash(s);
        }
        #endregion
        void Load()
        {

            CharaOne = Instantiate(CharaOnePre, this.transform);
            characters.Add(1, CharaOne);
            CharaTwo = Instantiate(CharaTwoPre, this.transform);
            characters.Add(2, CharaTwo);
            CharaThree = Instantiate(CharaThreePre, this.transform);
            characters.Add(3, CharaThree);
            CharaFour = Instantiate(CharaFourPre, this.transform);
            characters.Add(4, CharaFour);
        }

        public void changeMember(GameObject one, GameObject two, GameObject three, GameObject four)
        {
            CharaOnePre = one;
            CharaTwoPre = two;
            CharaThreePre = three;
            CharaFourPre = four;
        }

        private int changeCharaOnScene(int i, Transform targetTransform)
        {
            UnsubScribe(getChara(currentCharacter).GetComponentInChildren<CharaChangeUiEvents>());
            int prevChara = currentCharacter;
            currentCharacter = i;
            CharaOne.SetActive(false);
            CharaTwo.SetActive(false);
            CharaThree.SetActive(false);
            CharaFour.SetActive(false);
            characters[i].transform.position = targetTransform.position;
            subScribe(characters[i].GetComponentInChildren<CharaChangeUiEvents>());
            characters[i].SetActive(true);
            cam.follow(characters[i]);
            return prevChara;
        }

        public int changeCharaOnScene(int i)
        {

            return changeCharaOnScene(i, characters[currentCharacter].transform);


        }

        public void DisActiveAll()
        {
            CharaOne.SetActive(false);
            CharaTwo.SetActive(false);
            CharaThree.SetActive(false);
            CharaFour.SetActive(false);
        }

        public GameObject getChara(int i)
        {
            return characters[i];
        }
        void setActivation(bool Active)
        {
            if (!Active)
            {
                lastTrans = characters[currentCharacter].transform;
                DisActiveAll();
            }
            else
            {
                changeCharaOnScene(currentCharacter, lastTrans);
            }
        }


    }
}
