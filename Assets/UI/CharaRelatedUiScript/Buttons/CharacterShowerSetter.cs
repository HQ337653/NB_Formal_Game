using UnityEngine;
using TMPro;
namespace NBGame.UI
{
    public class CharacterShowerSetter : MonoBehaviour
    {
        public TextMeshProUGUI Displayedtext;
        public GameObject current;
        public void changeTo(GameObject character)
        {
            Displayedtext.text = character?.name;
        }
    }
}
