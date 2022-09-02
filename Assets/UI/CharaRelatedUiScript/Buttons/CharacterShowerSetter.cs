using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NBGame.Player;
namespace NBGame.UI
{
    public class CharacterShowerSetter : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI Displayedtext;
        [SerializeField] GameObject current;
        [SerializeField] Image characterImage;
        public void changeTo(GameObject character)
        {
            Displayedtext.text = character?.name;
           Sprite charaIcon = character.GetComponentInChildren<CharaModeSwitcher>().charaIcon;
            if (charaIcon!=null)
            {
                characterImage.sprite = charaIcon;
            }
        }

        public void showCooldown(float time)
        {
           
        }


        public void ActivateButton(bool ifActivate)
        {

        }
        public void characterDie(bool die)
        {

        }

    }
}
