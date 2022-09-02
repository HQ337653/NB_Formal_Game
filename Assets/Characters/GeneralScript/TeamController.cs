using System.Collections.Generic;
using UnityEngine;
using NBGame.CameraMovement;
using NBGame.UI;
namespace NBGame.Player
{
    //load character based on the given prefeb, and implement the changed of character in the scene
    public class TeamController : MonoBehaviour
    {
        
        //Prefeb
        public GameObject CharaOnePre;
        public GameObject CharaTwoPre;
        public GameObject CharaThreePre;
        public GameObject CharaFourPre;
        //CharacterInScene
        public Dictionary<int, GameObject> characters { get; private set; }
        //index of current character
        public int currentCharacter=1;
        Transform lastTrans;

        public bool ableToChange
        {
            get; private set;
        }
        [SerializeField]
        private CameraAnchor cam;
        [SerializeField]
        private UiController UiController;
        private void Awake()
        {
            ableToChange = true;
            currentCharacter = 1;
            GameModeController.CharacterChangedIfToActive += setActivation;
        }

        private void Start()
        {
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
 
        public  void Load()
        {
            currentCharacter = 1;
            characters= new Dictionary<int, GameObject>();
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            characters.Add(1, Instantiate(CharaOnePre, this.transform));
            UiController.specialBars.AddBar(characters[1].GetComponent<characterScripts>().position.GetComponent<CharaModeSwitcher>().specialBar);
            if (CharaTwoPre!=null)
            {
                characters.Add(2, Instantiate(CharaTwoPre, this.transform));
                UiController.specialBars.AddBar(characters[2].GetComponent<characterScripts>().position.GetComponent<CharaModeSwitcher>().specialBar);
                if (CharaThreePre != null)
                {
                    characters.Add(3, Instantiate(CharaThreePre, this.transform));
                    UiController.specialBars.AddBar(characters[3].GetComponent<characterScripts>().position.GetComponent<CharaModeSwitcher>().specialBar);
                    if (CharaFourPre!=null)
                    {
                        characters.Add(4, Instantiate(CharaFourPre, this.transform));
                        UiController.specialBars.AddBar(characters[4].GetComponent<characterScripts>().position.GetComponent<CharaModeSwitcher>().specialBar);
                    }
                }
            }
  
            changeCharaOnScene(currentCharacter);
            Loaded?.Invoke();
            TeamCharacterChanged?.Invoke();
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
            for(int j = 1; j <= characters.Count; j++)
            {
                characters[j]?.SetActive(false);
            }
            characters[i].transform.position = targetTransform.position;
            subScribe(characters[i].GetComponentInChildren<CharaChangeUiEvents>());
            characters[i].SetActive(true);
            cam.follow(characters[i].transform.GetChild(0).gameObject);
            CharacterChanged?.Invoke(currentCharacter);
            UiController.specialBars.setActivation(i);
            return prevChara;
        }

        public int changeCharaOnScene(int i)
        {

            return changeCharaOnScene(i, characters[currentCharacter].transform);


        }

        public void DisActiveAll()
        {
            characters[1].SetActive(false);
            characters[2].SetActive(false);
            characters[3].SetActive(false);
            characters[4].SetActive(false);
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

        public delegate void Event();
        public delegate void Character(int index);
        public event Event TeamCharacterChanged;
        public event Character CharacterChanged;
        public event Event Loaded;
    }
}
