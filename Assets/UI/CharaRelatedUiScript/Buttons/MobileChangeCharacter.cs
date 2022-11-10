using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NBGame.UI;
using System.Threading.Tasks;
using System.Collections;

namespace NBGame.Player
{
    public class MobileChangeCharacter : MonoBehaviour
    {
        [SerializeField]
        private GameObject first;
        [SerializeField]
        private GameObject second;
        [SerializeField]
        private GameObject third;
        [SerializeField]
        private GameObject ButtonPrefeb;
        //button index on and index of character in team 
        private Dictionary<CharacterShowerSetter, int> getCharaIndexFromButton=new Dictionary<CharacterShowerSetter, int>();
        //index of button and the button
        private Dictionary<int, CharacterShowerSetter> Buttons = new Dictionary<int, CharacterShowerSetter>();
        [SerializeField]
        TeamController currentController;

        float coolDownTime;
        bool canChange;

        private void Awake()
        {
            coolDownTime = 0.5f;
            currentController.Loaded += Initialize;
        }


        private void Initialize()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            StartCoroutine(LoadCurrentChara());
        }

        private IEnumerator LoadCurrentChara()
        {
            yield return null;
            canChange = true;
            for (int i = 1; i < currentController.characters.Count; i++)
            {
                GameObject g = Instantiate(ButtonPrefeb, transform);
              // int j = new int();

                int j = i;
                g.GetComponent<Button>().onClick.AddListener(delegate { if (currentController.ableToChange) changeCharacter(j); });
                g.name = "button" + i;
                Buttons[i] = g.GetComponent<CharacterShowerSetter>();
                getCharaIndexFromButton[g.GetComponent<CharacterShowerSetter>()] = i + 1;
                Buttons[i].changeTo(currentController.getChara(i + 1));

            }


        }
        private void changeCharacter(int i)
        {
            if (canChange) {
                //chara index try to get 

                int tryToGet = getCharaIndexFromButton[Buttons[i]];
                
                //chara changing from, and change chara on screen 
                int changeFrom = currentController.changeCharaOnScene(tryToGet);
                //set the index of chara on Buttons[i] to pervois one 
                getCharaIndexFromButton[Buttons[i]] = changeFrom;
                //change Button showed information 
                Buttons[i].changeTo(currentController.getChara(changeFrom));
                canChange = false;
                coolDown();
            }
        }

        async Task coolDown()
        {
            await Task.Delay((int)(coolDownTime*1000));
            canChange = true;
        }

    }
}
