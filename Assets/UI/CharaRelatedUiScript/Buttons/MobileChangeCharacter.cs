using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NBGame.UI;

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
        //button index on and index of character in team 
        private Dictionary<CharacterShowerSetter, int> getCharaIndexFromButton;
        //index of button and the button
        private Dictionary<int, CharacterShowerSetter> Buttons;
        [SerializeField]
        TeamController currentController;

        private void Awake()
        {
            first.GetComponent<Button>().onClick.AddListener(delegate { if (currentController.ableToChange) changeCharacter(1); });
            second.GetComponent<Button>().onClick.AddListener(delegate { if (currentController.ableToChange) changeCharacter(2); });
            third.GetComponent<Button>().onClick.AddListener(delegate { if (currentController.ableToChange) changeCharacter(3); });
            Buttons = new Dictionary<int, CharacterShowerSetter>
            {
                [1] = first.GetComponent<CharacterShowerSetter>(),
                [2] = second.GetComponent<CharacterShowerSetter>(),
                [3] = third.GetComponent<CharacterShowerSetter>()
            };
            getCharaIndexFromButton = new Dictionary<CharacterShowerSetter, int>
            {
                [first.GetComponent<CharacterShowerSetter>()] = 2,
                [second.GetComponent<CharacterShowerSetter>()] = 3,
                [third.GetComponent<CharacterShowerSetter>()] = 4
            };
        }

        private void Start()
        {
            Buttons[1].changeTo(currentController.getChara(2));
            Buttons[2].changeTo(currentController.getChara(3));
            Buttons[3].changeTo(currentController.getChara(4));
        }
        public void changeCharacter(int i)
        {
            //chara index try to get 
            int tryToGet = getCharaIndexFromButton[Buttons[i]];
            //chara changing from, and change chara on screen 
            int changeFrom = currentController.changeCharaOnScene(tryToGet);
            //set the index of chara on Buttons[i] to pervois one 
            getCharaIndexFromButton[Buttons[i]] = changeFrom;
            //change Button showed information 
            Buttons[i].changeTo(currentController.getChara(changeFrom));
        }

    }
}
