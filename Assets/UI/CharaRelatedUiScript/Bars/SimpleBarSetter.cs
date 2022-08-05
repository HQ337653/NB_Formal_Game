using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace NBGame.UI
{
    public class SimpleBarSetter : MonoBehaviour
    {
        Slider thisSlider;
        private void Awake()
        {
            thisSlider = GetComponent<Slider>();
        }
        public void setValue(float percent)
        {
            thisSlider.value = percent;
        }
    }
}
