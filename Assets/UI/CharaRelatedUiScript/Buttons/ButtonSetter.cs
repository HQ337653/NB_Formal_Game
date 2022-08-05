using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace NBGame.UI
{
    public class ButtonSetter : MonoBehaviour
    {
        [SerializeField]
        Image Image;
        [SerializeField]
        TextMeshProUGUI t;
        public void setBackgroundColor(Color c)
        {

        }

        public void setTexture(Sprite c)
        {
            Image.sprite = c;
        }

        public void HighLight(bool highLight)
        {

        }
        public void conutTime(float time)
        {

        }
    }
}
