using UnityEngine;
using NBGame.UI;
namespace NBGame.Player
{
    public class PcChangeCharacter : MonoBehaviour
    {
        [SerializeField]
        private GameObject first;
        [SerializeField]
        private GameObject second;
        [SerializeField]
        private GameObject third;
        [SerializeField]
        private GameObject Four;
        [SerializeField]
        TeamController currentController;

        PlayerInput inputActions;
        private void Awake()
        {
            inputActions = new PlayerInput();
            inputActions.Enable();
        }


        private void Start()
        {
            first.GetComponent<CharacterShowerSetter>().changeTo(currentController.getChara(1));
            second.GetComponent<CharacterShowerSetter>().changeTo(currentController.getChara(2));
            third.GetComponent<CharacterShowerSetter>().changeTo(currentController.getChara(3));
            Four.GetComponent<CharacterShowerSetter>().changeTo(currentController.getChara(4));

            inputActions.Universal.changeChara1.performed += ctx => { if (currentController.ableToChange && currentController.currentCharacter != 1) currentController.changeCharaOnScene(1); };
            inputActions.Universal.changeChara2.performed += ctx => { if (currentController.ableToChange && currentController.currentCharacter != 2) currentController.changeCharaOnScene(2); };
            inputActions.Universal.changeChara3.performed += ctx => { if (currentController.ableToChange && currentController.currentCharacter != 3) currentController.changeCharaOnScene(3); };
            inputActions.Universal.changeChara4.performed += ctx => { if (currentController.ableToChange && currentController.currentCharacter != 4) currentController.changeCharaOnScene(4); };
        }
    }
}