using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace NBGame.UI
{
    public class SimpleBarSetter : MonoBehaviour
    {
        [SerializeField]
       public Slider S;
        private void Awake()
        {
            S = GetComponent<Slider>();
        }


        public void setValue(float percent)
        {
            S.value = percent;
        }
    }
}
