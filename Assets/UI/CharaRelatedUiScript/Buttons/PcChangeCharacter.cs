using UnityEngine;
using NBGame.UI;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;

namespace NBGame.Player
{
    //call the change of character on pc
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
        [SerializeField]
        GameObject buttonPrefeb;
        PlayerInput inputActions;

        float coolDownTime=0.5f;
        bool canChange;

        List<GameObject> buttons = new List<GameObject>();
        private void Awake()
        {
            inputActions = new PlayerInput();
            inputActions.Enable();
            canChange = true;
            currentController.Loaded += Initialize;
        }
        private void Initialize()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            StartCoroutine(LoadCurrentTeam());
        }

        private IEnumerator LoadCurrentTeam()
        {
              yield return null;
              for (int i = 1; i <= currentController.characters.Count; i++)
              {
                  GameObject g = Instantiate(buttonPrefeb, transform);
                  g.GetComponent<CharacterShowerSetter>().changeTo(currentController.getChara(i));
                  buttons.Insert(0, g);
              }
             inputActions.Universal.changeChara1.performed += ctx => { if (canChange && currentController.ableToChange && currentController.currentCharacter != 1) { currentController.changeCharaOnScene(1); coolDown(); } };

            //if the team controller currently have less than 4 character, not assigning input action accordingly
              if (currentController.characters.Count > 1)
              {
                  inputActions.Universal.changeChara2.performed += ctx => { if (canChange && currentController.ableToChange && currentController.currentCharacter != 2) { currentController.changeCharaOnScene(2); coolDown(); } };
                  if (currentController.characters.Count > 2)
                  {
                      inputActions.Universal.changeChara3.performed += ctx => { if (canChange && currentController.ableToChange && currentController.currentCharacter != 3) { currentController.changeCharaOnScene(3); coolDown(); } };
                      if (currentController.characters.Count > 3)
                      {
                          inputActions.Universal.changeChara4.performed += ctx => { if (canChange && currentController.ableToChange && currentController.currentCharacter != 4) { currentController.changeCharaOnScene(4); coolDown();  } };
                      }
                  }

              }


        }

        async Task coolDown()
        {
            canChange = false;
            await Task.Delay((int)(coolDownTime * 1000));
            canChange = true;
        }
    }
}